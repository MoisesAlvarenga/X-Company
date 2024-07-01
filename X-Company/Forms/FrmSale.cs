using System.Data;
using XCompany.Data.Entities;
using XCompany.Services;

namespace XCompany
{
    public partial class FrmSale : Form
    {
        // Evento que será disparado quando uma venda for concluída.
        public event EventHandler SaleCompleted;

        // Declaração dos serviços necessários.
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        // Lista de itens de venda e produtos disponíveis.
        private List<Saleitem> _saleItems = new List<Saleitem>();
        private readonly List<Product> _products = new List<Product>();

        // Construtor da classe FrmSale, inicializando os serviços injetados.
        public FrmSale(IProductService productService, ICustomerService customerService, ISaleService saleService)
        {
            _productService = productService;
            _customerService = customerService;
            _saleService = saleService;
            InitializeComponent();
        }

        // Método assíncrono para carregar a lista de clientes no comboBox.
        private async Task LoadCustomersAsync()
        {
            var customers = await _customerService.GetAllAsync();
            comboBoxCustomer.DataSource = customers.ToList();
            comboBoxCustomer.DisplayMember = "Name";
        }

        // Método assíncrono para carregar a lista de produtos com estoque disponível no comboBox.
        private async Task LoadProductAsync()
        {
            var productResult = await _productService.FilterByAsync(x => x.Stock > 0);
            if (productResult != null) _products.AddRange(productResult);
            comboBoxProduct.DataSource = _products.ToList();
            comboBoxProduct.DisplayMember = "Name";

            if (comboBoxProduct.SelectedItem is Product selectedProduct)
            {
                textBoxPrice.Text = selectedProduct.Price.ToString();
                textBoxDescription.Text = selectedProduct.Description;
            }
        }

        // Evento ao clicar no botão "Adicionar Produto".
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductToSale();
        }

        // Método para adicionar o produto selecionado à lista de itens de venda.
        private void AddProductToSale()
        {
            if (comboBoxProduct.SelectedItem is Product selectedProduct && numericUpDownAmount.Value > 0)
            {
                // Verifica se o item já existe na lista e atualiza a quantidade se necessário.
                var existingItem = _saleItems.FirstOrDefault(si => si.ProductId == selectedProduct.Id);

                if (existingItem != null)
                {
                    if (existingItem.Amount >= selectedProduct.Stock)
                    {
                        MessageBox.Show("Não há mais quantidade disponível no estoque.", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        existingItem.Amount += (int)numericUpDownAmount.Value;
                    }
                }
                else
                {
                    var saleItem = new Saleitem
                    {
                        ProductId = selectedProduct.Id,
                        Amount = (int)numericUpDownAmount.Value,
                        Product = selectedProduct
                    };
                    _saleItems.Add(saleItem);
                }

                UpdateListView();
            }
            else
            {
                MessageBox.Show("Selecione um produto e insira uma quantidade válida.", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownAmount.Focus();
            }
        }

        // Método para atualizar a exibição da lista de produtos na ListView.
        private void UpdateListView()
        {
            listViewProductsToSale.Items.Clear();
            decimal total = 0;

            foreach (var item in _saleItems)
            {
                var product = _products.FirstOrDefault(x => x.Id == item.ProductId);
                if (product != null)
                {
                    var price = product.Price;
                    var listViewItem = new ListViewItem(product.Name);
                    listViewItem.SubItems.Add(product.Description);
                    listViewItem.SubItems.Add(price.ToString("C"));
                    listViewItem.SubItems.Add(item.Amount.ToString());
                    listViewProductsToSale.Items.Add(listViewItem);
                    item.Product = null;

                    total += price * item.Amount;
                }
            }

            if (listViewProductsToSale.Items.Count > 0)
            {
                listViewProductsToSale.Items[listViewProductsToSale.Items.Count - 1].Selected = true;
                listViewProductsToSale.Items[listViewProductsToSale.Items.Count - 1].EnsureVisible();
            }

            textBoxTotal.Text = total.ToString("C");
        }

        // Evento ao clicar no botão "Remover Produto".
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (listViewProductsToSale.SelectedItems.Count > 0)
            {
                var selectedIndex = listViewProductsToSale.SelectedItems[0].Index;
                _saleItems.RemoveAt(selectedIndex);
                UpdateListView();
            }
        }

        // Atualiza o valor máximo do controle numericUpDown com base no estoque do produto.
        private void UpdateNumericUpDownMaximumProduct(int stock)
        {
            numericUpDownAmount.Maximum = stock;
        }

        // Evento ao mudar a seleção no comboBox de produtos.
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem is Product selectedProduct)
            {
                textBoxPrice.Text = selectedProduct.Price.ToString();
                textBoxDescription.Text = selectedProduct.Description;
                textBoxStockStock.Text = selectedProduct.Stock.ToString();
                UpdateNumericUpDownMaximumProduct(selectedProduct.Stock);
            }
        }

        // Evento assíncrono ao clicar no botão "Realizar Venda".
        private async void btnMakeSale_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedItem is Customer selectedCustomer)
            {
                var sale = new Sale
                {
                    CustomerId = selectedCustomer.Id,
                    SaleDate = DateTime.Now,
                    SaleItems = _saleItems,
                    Customer = null
                };
                try
                {
                    await _saleService.AddAsync(sale);
                    foreach (var saleItem in _saleItems)
                    {
                        var product = _products.FirstOrDefault(x => x.Id == saleItem.ProductId);
                        if (product != null)
                        {
                            product.Stock -= saleItem.Amount;
                            await _productService.UpdateAsync(product);
                        }
                    }

                    _saleItems = new List<Saleitem>();
                    RemoveProductsOutOfStock();

                    MessageBox.Show("Venda realizada com sucesso!");
                    ClearForm();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para remover produtos que estão fora de estoque da lista de produtos disponíveis.
        private void RemoveProductsOutOfStock()
        {
            var productsToRemove = _products.Where(p => p.Stock <= 0).ToList();

            foreach (var product in productsToRemove)
            {
                _products.Remove(product);
            }
            comboBoxProduct.DataSource = null;
            comboBoxProduct.DataSource = _products.ToList();
            comboBoxProduct.DisplayMember = "Name";
        }

        // Método para limpar o formulário de venda.
        private void ClearForm()
        {
            comboBoxCustomer.SelectedIndex = -1;
            comboBoxProduct.SelectedIndex = -1;
            numericUpDownAmount.Value = 1;
            textBoxPrice.Clear();
            textBoxDescription.Clear();
            _saleItems.Clear();
            UpdateListView();
        }

        // Evento ao pressionar uma tecla no formulário.
        private void SaleForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnAddProduct_Click(sender, e);
                    break;
                case Keys.F2:
                    btnRemoveProduct_Click(sender, e);
                    break;
                case Keys.F4:
                    btnMakeSale_Click(sender, e);
                    break;
            }
        }

        // Evento ao carregar o formulário de venda.
        private void FrmSale_Load(object sender, EventArgs e)
        {
            LoadCustomersAsync();
            LoadProductAsync();
        }
    }
}

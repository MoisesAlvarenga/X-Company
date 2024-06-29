using XCompany;
using XCompany.Data.Entities;
using XCompany.Services;

namespace WinFormsApp1
{
    public partial class frmDashboard : Form
    {
        // Declara��o de vari�veis para armazenar as inst�ncias dos formul�rios de produtos, clientes e vendas.
        private ProductForms _productForm;
        private CustomerForm _customerForm;
        private FrmSale _saleForm;
        private List<Sale> _sales = new List<Sale>();

        // Declara��o de servi�os que ser�o injetados via construtor para manipula��o de vendas, produtos e clientes.
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        // Construtor do frmDashboard, onde os servi�os s�o injetados e o componente � inicializado.
        public frmDashboard(IProductService productService, ICustomerService customerService, ISaleService saleService)
        {
            _productService = productService;
            _customerService = customerService;
            _saleService = saleService;
            InitializeComponent();
        }

        // M�todo ass�ncrono para carregar as vendas no ListView.
        private async Task LoadListViewSalesAsync()
        {
            // Limpa os itens existentes no ListView.
            listViewSale.Items.Clear();

            // Obt�m todas as vendas com itens e clientes associados de forma ass�ncrona.
            var sales = await _saleService.GetAllWithSaleItemsAndCustomerAsync();

            // Obt�m os IDs dos produtos das vendas.
            var productIds = sales.SelectMany(s => s.Saleitems.Select(si => si.Productid)).Distinct().ToList();
            // Filtra os produtos com base nos IDs obtidos.
            var productList = await _productService.FilterByAsync(x => productIds.Contains(x.Id));

            // Itera sobre cada venda.
            foreach (var sale in sales)
            {
                // Cria um item para o ListView com o nome do cliente ou "Cliente n�o encontrado".
                ListViewItem item = new ListViewItem(sale?.Customer?.Name ?? "Cliente n�o encontrado");

                // Adiciona a data da venda como subitem.
                item.SubItems.Add(sale.Saledate.ToString("dd/MM/yyyy"));

                // Calcula o total de itens vendidos e adiciona como subitem.
                int totalAmount = sale.Saleitems.Sum(x => x.Amount);
                item.SubItems.Add(totalAmount.ToString());

                // Obt�m IDs �nicos dos produtos vendidos.
                var uniqueProductIds = sale.Saleitems.Select(si => si.Productid).Distinct().ToList();

                // Filtra os produtos atuais com base nos IDs �nicos.
                var currentProducts = productList.Where(p => uniqueProductIds.Contains(p.Id)).ToList();

                // Calcula o pre�o total da venda e adiciona como subitem.
                decimal totalPrice = sale.Saleitems.Sum(si =>
                {
                    var product = currentProducts.FirstOrDefault(p => p.Id == si.Productid);
                    return (product?.Price ?? 0) * si.Amount;
                });
                item.SubItems.Add(totalPrice.ToString("F2"));

                // Adiciona o item ao ListView.
                listViewSale.Items.Add(item);
            }
        }

        // Evento para abrir o formul�rio de vendas ao clicar no bot�o "Fazer Venda".
        private void btnMakeSale_Click(object sender, EventArgs e)
        {
            if (_saleForm == null || _saleForm.IsDisposed)
            {
                _saleForm = new FrmSale(_productService, _customerService, _saleService);
                _saleForm.Show();
            }
            else
            {
                _productForm.Activate();
            }
        }

        // Evento para abrir o formul�rio de produtos ao clicar no item de menu "Produtos".
        private void toolStripMenuItemProducts_Click(object sender, EventArgs e)
        {
            if (_productForm == null || _productForm.IsDisposed)
            {
                _productForm = new ProductForms(_productService);
                _productForm.Show();
            }
            else
            {
                _productForm.Activate();
            }
        }

        // Evento para abrir o formul�rio de clientes ao clicar no item de menu "Clientes".
        private void toolStripMenuItemCustomers_Click(object sender, EventArgs e)
        {
            if (_customerForm == null || _customerForm.IsDisposed)
            {
                _customerForm = new CustomerForm(_customerService);
                _customerForm.Show();
            }
            else
            {
                _customerForm.Activate();
            }
        }

        // Evento para gerenciar atalhos de teclado e abrir os formul�rios correspondentes.
        private void saleForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    toolStripMenuItemProducts_Click(sender, e);
                    break;
                case Keys.F2:
                    toolStripMenuItemCustomers_Click(sender, e);
                    break;
                case Keys.F3:
                    btnMakeSale_Click(sender, e);
                    break;
            }
        }

        // Evento para carregar as vendas ao iniciar o formul�rio.
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadListViewSalesAsync();
        }
    }
}

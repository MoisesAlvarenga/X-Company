using Microsoft.EntityFrameworkCore;
using XCompany.Data.Entities;
using XCompany.Services;

namespace XCompany
{
    public partial class ProductForms : Form
    {
        // Declaração do serviço de produto que será injetado via construtor.
        private readonly IProductService _productService;

        // Construtor do ProductForms, onde o serviço é injetado e o componente é inicializado.
        public ProductForms(IProductService productService)
        {
            _productService = productService;
            InitializeComponent();
        }

        // Método para limpar os campos de entrada do formulário de produto.
        private void ClearProductFields()
        {
            nameTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            priceUpDown.Text = "1";
            stockUpDown2.Text = "0";
            comboBoxProduct.SelectedItem = null;
            btnDeleteProduct.Visible = true;
        }

        // Método assíncrono para carregar a lista de produtos no comboBox.
        private async Task LoadProductAsync()
        {
            var products = await _productService.GetAllAsync();
            comboBoxProduct.DataSource = products.ToList();
            comboBoxProduct.DisplayMember = "Name";
        }

        // Evento ao mudar a seleção no comboBox de produtos.
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem is Product selectedProduct)
            {
                // Preenche os campos do formulário com os dados do produto selecionado.
                nameTextBox.Text = selectedProduct.Name;
                descriptionTextBox.Text = selectedProduct.Description;
                priceUpDown.Text = selectedProduct.Price.ToString();
                stockUpDown2.Text = selectedProduct.Stock.ToString();
                btnDeleteProduct.Visible = true;
            }
        }

        // Evento assíncrono ao clicar no botão "Deletar Produto".
        private async void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem is Product selectedProduct)
            {
                // Mostra uma mensagem de confirmação para deletar o produto.
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tenta remover o produto de forma assíncrona.
                        await _productService.RemoveAsync(selectedProduct.Id);
                        MessageBox.Show("Produto removido com sucesso!");

                        ClearProductFields();
                        await LoadProductAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        if (IsForeignKeyViolationException(ex))
                        {
                            MessageBox.Show("Não é possível excluir este produto porque existem vendas associadas a ele.", "Erro ao Remover Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Erro ao Remover Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para deletar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para verificar se a exceção é uma violação de chave estrangeira.
        private bool IsForeignKeyViolationException(DbUpdateException ex)
        {
            return ex.InnerException is Npgsql.PostgresException postgresException &&
                   postgresException.SqlState == "23503";
        }

        // Evento ao carregar o formulário de produto.
        private async void ProductForms_Load(object sender, EventArgs e)
        {
            await LoadProductAsync();
        }

        // Evento assíncrono ao clicar no botão "Salvar Produto".
        private async void btnSaveProduct_Click(object sender, EventArgs e)
        {
            // Obtém os dados dos campos de entrada.
            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;
            decimal price = priceUpDown.Value;
            int stock = (int)stockUpDown2.Value;

            // Cria um novo produto com os dados fornecidos.
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                Stock = stock
            };

            try
            {
                // Tenta adicionar o novo produto de forma assíncrona.
                await _productService.AddAsync(product);
                MessageBox.Show("Produto salvo com sucesso!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ocorreu um erro ao salvar o produto: {ex.Message}");
            }
        }

        // Evento ao clicar no botão "Novo Produto".
        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            ClearProductFields();
            btnDeleteProduct.Visible = false;
        }
    }
}

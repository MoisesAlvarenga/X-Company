using XCompany.Services;
using Microsoft.EntityFrameworkCore;
using XCompany.Data.Entities;

namespace XCompany
{
    public partial class CustomerForm : Form
    {
        // Declaração do serviço de cliente que será injetado via construtor.
        private readonly ICustomerService _customerService;

        // Construtor do CustomerForm, onde o serviço é injetado e o componente é inicializado.
        public CustomerForm(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        // Evento ao clicar no botão "Novo Cliente".
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            // Limpa os campos de entrada e deseleciona o cliente no comboBox.
            textBoxName.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
            addressTextBox.Text = string.Empty;
            comboBoxCustomers.SelectedItem = null;
            btnDeleteCustomer.Visible = false;
        }

        // Evento assíncrono ao clicar no botão "Salvar Cliente".
        private async void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            // Validação para verificar se o campo nome está vazio.
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("O nome do cliente é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se um cliente existente foi selecionado para atualização.
            if (comboBoxCustomers.SelectedItem is Customer selectedCustomer)
            {
                // Atualiza os dados do cliente selecionado.
                selectedCustomer.Name = textBoxName.Text;
                selectedCustomer.Email = textBoxEmail.Text;
                selectedCustomer.Phone = textBoxPhone.Text;
                selectedCustomer.Address = addressTextBox.Text;

                try
                {
                    // Tenta atualizar o cliente de forma assíncrona.
                    await _customerService.UpdateAsync(selectedCustomer);
                    MessageBox.Show("Cliente atualizado com sucesso!");
                    ClearCustomerFields();
                    await LoadCustomersAsync();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Cria um novo cliente com os dados fornecidos.
                var newCustomer = new Customer
                {
                    Name = textBoxName.Text,
                    Email = textBoxEmail.Text,
                    Phone = textBoxPhone.Text,
                    Address = addressTextBox.Text
                };

                try
                {
                    // Tenta adicionar o novo cliente de forma assíncrona.
                    await _customerService.AddAsync(newCustomer);
                    MessageBox.Show("Cliente adicionado com sucesso!");
                    ClearCustomerFields();
                    await LoadCustomersAsync();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento assíncrono ao clicar no botão "Deletar Cliente".
        private async void deletebutton_Click(object sender, EventArgs e)
        {
            // Verifica se um cliente foi selecionado.
            if (comboBoxCustomers.SelectedItem is Customer selectedCustomer)
            {
                // Mostra uma mensagem de confirmação para deletar o cliente.
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tenta remover o cliente de forma assíncrona.
                        await _customerService.RemoveAsync(selectedCustomer.Id);
                        MessageBox.Show("Cliente removido com sucesso!");

                        ClearCustomerFields();
                        await LoadCustomersAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        if (IsForeignKeyViolationException(ex))
                        {
                            MessageBox.Show("Não é possível excluir este cliente porque existem vendas associadas a ele.", "Erro ao Remover Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Erro ao Remover Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para deletar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para verificar se a exceção é uma violação de chave estrangeira.
        private bool IsForeignKeyViolationException(DbUpdateException ex)
        {
            return ex.InnerException is Npgsql.PostgresException postgresException &&
                   postgresException.SqlState == "23503";
        }

        // Método assíncrono para carregar a lista de clientes no comboBox.
        private async Task LoadCustomersAsync()
        {
            var customers = await _customerService.GetAllAsync();
            comboBoxCustomers.DataSource = customers.ToList();
            comboBoxCustomers.DisplayMember = "Name";
        }

        // Método para limpar os campos do formulário de cliente.
        private void ClearCustomerFields()
        {
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxPhone.Text = "";
            addressTextBox.Text = "";
        }

        // Evento ao carregar o formulário de cliente.
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomersAsync();
        }

        // Evento para gerenciar atalhos de teclado e executar ações correspondentes.
        private void CustomerForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnNewCustomer_Click(sender, e);
                    break;
                case Keys.F2:
                    deletebutton_Click(sender, e);
                    break;
                case Keys.F4:
                    btnSaveCustomer_Click(sender, e);
                    break;
            }
        }

        // Evento ao mudar a seleção no comboBox de clientes.
        private void comboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomers.SelectedItem is Customer selectedCustomer)
            {
                textBoxName.Text = selectedCustomer.Name;
                textBoxEmail.Text = selectedCustomer.Email;
                textBoxPhone.Text = selectedCustomer.Phone;
                addressTextBox.Text = selectedCustomer.Address;
                btnDeleteCustomer.Visible = true;
            }
        }
    }
}

using System.Text.RegularExpressions;
using XCompany.Data.Entities;
using XCompany.Data.Repositories;

namespace XCompany.Services
{
    /// <summary>
    /// Serviço para manipulação de entidades de clientes.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        /// <summary>
        /// Construtor que recebe uma implementação de repositório para clientes.
        /// </summary>
        /// <param name="repository">Repositório para manipulação de dados de clientes.</param>
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtém um cliente pelo seu ID.
        /// </summary>
        /// <param name="id">ID do cliente.</param>
        /// <returns>O cliente com o ID especificado.</returns>
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <summary>
        /// Obtém todos os clientes.
        /// </summary>
        /// <returns>Uma coleção de todos os clientes.</returns>
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        /// <param name="customer">Cliente a ser adicionado.</param>
        /// <exception cref="ArgumentException">Lançada se o cliente for inválido ou se o email já estiver cadastrado.</exception>
        public async Task AddAsync(Customer customer)
        {
            ValidateCustomer(customer);

            if (await EmailExistsAsync(customer.Email))
            {
                throw new ArgumentException("Email já cadastrado.");
            }

            await _repository.AddAsync(customer);
        }

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="customer">Cliente com os dados atualizados.</param>
        /// <exception cref="ArgumentException">Lançada se o cliente for inválido, se o cliente não for encontrado ou se o email já estiver cadastrado.</exception>
        public async Task UpdateAsync(Customer customer)
        {
            ValidateCustomer(customer);

            var existingCustomer = await _repository.GetByIdAsync(customer.Id);
            if (existingCustomer == null)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }

            if (existingCustomer.Email != customer.Email && await EmailExistsAsync(customer.Email))
            {
                throw new ArgumentException("Email já cadastrado.");
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;

            await _repository.Update(existingCustomer);
        }

        /// <summary>
        /// Remove um cliente pelo seu ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser removido.</param>
        /// <exception cref="ArgumentException">Lançada se o cliente não for encontrado.</exception>
        public async Task RemoveAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }

            await _repository.RemoveAsync(customer);
        }

        /// <summary>
        /// Valida os dados de um cliente.
        /// </summary>
        /// <param name="customer">Cliente a ser validado.</param>
        /// <exception cref="ArgumentException">Lançada se os dados do cliente forem inválidos.</exception>
        private void ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(customer.Email) || !IsValidEmail(customer.Email))
            {
                throw new ArgumentException("Email inválido.");
            }

            if (string.IsNullOrWhiteSpace(customer.Phone) || !IsValidPhone(customer.Phone))
            {
                throw new ArgumentException("Número de telefone inválido.");
            }

            if (string.IsNullOrWhiteSpace(customer.Address))
            {
                throw new ArgumentException("O endereço é obrigatório.");
            }
        }

        /// <summary>
        /// Verifica se um email é válido.
        /// </summary>
        /// <param name="email">Email a ser verificado.</param>
        /// <returns>Verdadeiro se o email for válido; caso contrário, falso.</returns>
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        /// <summary>
        /// Verifica se um número de telefone é válido.
        /// </summary>
        /// <param name="phone">Número de telefone a ser verificado.</param>
        /// <returns>Verdadeiro se o número de telefone for válido; caso contrário, falso.</returns>
        private bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit);
        }

        /// <summary>
        /// Verifica se um email já está cadastrado.
        /// </summary>
        /// <param name="email">Email a ser verificado.</param>
        /// <returns>Verdadeiro se o email já estiver cadastrado; caso contrário, falso.</returns>
        private async Task<bool> EmailExistsAsync(string email)
        {
            var customers = await _repository.FindAsync(c => c.Email == email);
            return customers.Any();
        }
    }
}

using XCompany.Data.Entities;


namespace XCompany.Services
{
    /// <summary>
    /// Interface que define os métodos para manipulação de entidades de clientes.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Obtém um cliente pelo seu ID.
        /// </summary>
        /// <param name="id">ID do cliente.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta no cliente com o ID especificado.</returns>
        Task<Customer> GetByIdAsync(int id);

        /// <summary>
        /// Obtém todos os clientes.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de todos os clientes.</returns>
        Task<IEnumerable<Customer>> GetAllAsync();

        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        /// <param name="customer">Cliente a ser adicionado.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task AddAsync(Customer customer);

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="customer">Cliente com os dados atualizados.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task UpdateAsync(Customer customer);

        /// <summary>
        /// Remove um cliente pelo seu ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser removido.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task RemoveAsync(int id);
    }
}

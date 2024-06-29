using XCompany.Data.Entities;

namespace XCompany.Services
{
    /// <summary>
    /// Interface para serviço de manipulação de vendas.
    /// </summary>
    public interface ISaleService
    {
        /// <summary>
        /// Obtém todas as vendas.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de todas as vendas.</returns>
        Task<IEnumerable<Sale>> GetAllAsync();

        /// <summary>
        /// Obtém todas as vendas incluindo itens de venda e clientes.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de todas as vendas com itens de venda e clientes incluídos.</returns>
        Task<IEnumerable<Sale>> GetAllWithSaleItemsAndCustomerAsync();

        /// <summary>
        /// Obtém uma venda pelo seu ID.
        /// </summary>
        /// <param name="id">ID da venda.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta na venda com o ID especificado.</returns>
        Task<Sale> GetByIdAsync(int id);

        /// <summary>
        /// Adiciona uma nova venda.
        /// </summary>
        /// <param name="sale">Venda a ser adicionada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task AddAsync(Sale sale);

        /// <summary>
        /// Atualiza uma venda existente.
        /// </summary>
        /// <param name="sale">Venda com os dados atualizados.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task UpdateAsync(Sale sale);

        /// <summary>
        /// Remove uma venda pelo seu ID.
        /// </summary>
        /// <param name="id">ID da venda a ser removida.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task RemoveAsync(int id);
    }
}

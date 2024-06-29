using System.Linq.Expressions;
using XCompany.Data.Entities;

namespace XCompany.Services
{
    /// <summary>
    /// Interface para o serviço de manipulação de produtos.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Obtém um produto pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta no produto com o ID especificado.</returns>
        Task<Product> GetByIdAsync(int id);

        /// <summary>
        /// Obtém todos os produtos.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de todos os produtos.</returns>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Filtra produtos com base em um predicado.
        /// </summary>
        /// <param name="predicate">Expressão de predicado para filtrar produtos.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de produtos que atendem ao predicado.</returns>
        Task<IEnumerable<Product>> FilterByAsync(Expression<Func<Product, bool>> predicate);

        /// <summary>
        /// Encontra produtos pelos seus IDs.
        /// </summary>
        /// <param name="productIds">IDs dos produtos.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de produtos com os IDs especificados.</returns>
        Task<IEnumerable<Product>> FindProductsByIdsAsync(IEnumerable<int> productIds);

        /// <summary>
        /// Adiciona um novo produto.
        /// </summary>
        /// <param name="product">Produto a ser adicionado.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task AddAsync(Product product);

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="product">Produto com os dados atualizados.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task UpdateAsync(Product product);

        /// <summary>
        /// Remove um produto pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto a ser removido.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task RemoveAsync(int id);
    }
}

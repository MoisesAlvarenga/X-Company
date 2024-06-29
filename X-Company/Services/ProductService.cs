using System.Linq.Expressions;
using XCompany.Data.Entities;
using XCompany.Data.Repositories;

namespace XCompany.Services
{
    /// <summary>
    /// Serviço para manipulação de produtos.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ProductService"/>.
        /// </summary>
        /// <param name="repository">Repositório de produtos.</param>
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtém um produto pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta no produto com o ID especificado.</returns>
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <summary>
        /// Filtra produtos com base em um predicado.
        /// </summary>
        /// <param name="predicate">Expressão de predicado para filtrar produtos.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de produtos que atendem ao predicado.</returns>
        public async Task<IEnumerable<Product>> FilterByAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        /// <summary>
        /// Encontra produtos pelos seus IDs.
        /// </summary>
        /// <param name="productIds">IDs dos produtos.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de produtos com os IDs especificados.</returns>
        public async Task<IEnumerable<Product>> FindProductsByIdsAsync(IEnumerable<int> productIds)
        {
            var ids = string.Join(",", productIds);
            var query = $"SELECT * FROM Products WHERE Id IN ({ids})";
            return await _repository.FindBySqlAsync(query);
        }

        /// <summary>
        /// Obtém todos os produtos.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de todos os produtos.</returns>
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>
        /// Adiciona um novo produto.
        /// </summary>
        /// <param name="product">Produto a ser adicionado.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task AddAsync(Product product)
        {
            ValidateProduct(product);
            await _repository.AddAsync(product);
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="product">Produto com os dados atualizados.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task UpdateAsync(Product product)
        {
            ValidateProduct(product);

            var existingProduct = await _repository.GetByIdAsync(product.Id);
            if (existingProduct == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            await _repository.Update(existingProduct);
        }

        /// <summary>
        /// Remove um produto pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto a ser removido.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task RemoveAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            await _repository.RemoveAsync(product);
        }

        /// <summary>
        /// Valida os dados de um produto.
        /// </summary>
        /// <param name="product">Produto a ser validado.</param>
        /// <exception cref="ArgumentException">Lançada quando o produto é inválido.</exception>
        private void ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("O nome do produto é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(product.Description))
            {
                throw new ArgumentException("A descrição do produto é obrigatória.");
            }

            if (product.Price <= 0)
            {
                throw new ArgumentException("O preço do produto deve ser maior que zero.");
            }

            if (product.Stock < 0)
            {
                throw new ArgumentException("O estoque do produto não pode ser negativo.");
            }
        }
    }
}

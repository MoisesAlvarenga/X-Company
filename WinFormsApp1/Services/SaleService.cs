using XCompany.Data.Entities;
using XCompany.Data.Repositories;

namespace XCompany.Services
{
    /// <summary>
    /// Serviço para manipulação de vendas.
    /// </summary>
    public class SaleService : ISaleService
    {
        private readonly IRepository<Sale> _saleRepository;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="SaleService"/>.
        /// </summary>
        /// <param name="saleRepository">Repositório de vendas.</param>
        public SaleService(IRepository<Sale> saleRepository)
        {
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Obtém todas as vendas.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de todas as vendas.</returns>
        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _saleRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém uma venda pelo seu ID.
        /// </summary>
        /// <param name="id">ID da venda.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta na venda com o ID especificado.</returns>
        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _saleRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Obtém todas as vendas incluindo itens de venda e clientes.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. A tarefa resulta em uma coleção de todas as vendas com itens de venda e clientes incluídos.</returns>
        public async Task<IEnumerable<Sale>> GetAllWithSaleItemsAndCustomerAsync()
        {
            var sales = await _saleRepository.GetAllWithIncludeAsync(
                s => s.Saleitems,   // Incluir Saleitem
                s => s.Customer     // Incluir Customer
            );

            return sales;
        }

        /// <summary>
        /// Adiciona uma nova venda.
        /// </summary>
        /// <param name="sale">Venda a ser adicionada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task AddAsync(Sale sale)
        {
            ValidateSale(sale);
            await _saleRepository.AddAsync(sale);
        }

        /// <summary>
        /// Atualiza uma venda existente.
        /// </summary>
        /// <param name="sale">Venda com os dados atualizados.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task UpdateAsync(Sale sale)
        {
            ValidateSale(sale);

            var existingSale = await _saleRepository.GetByIdAsync(sale.Id);
            if (existingSale == null)
            {
                throw new ArgumentException("Venda não encontrada.");
            }

            existingSale.Saledate = sale.Saledate;
            _saleRepository.Update(existingSale);
        }

        /// <summary>
        /// Remove uma venda pelo seu ID.
        /// </summary>
        /// <param name="id">ID da venda a ser removida.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task RemoveAsync(int id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
            {
                throw new ArgumentException("Venda não encontrada.");
            }

            _saleRepository.Remove(sale);
        }

        /// <summary>
        /// Valida uma venda.
        /// </summary>
        /// <param name="sale">Venda a ser validada.</param>
        private void ValidateSale(Sale sale)
        {
            if (sale.Saledate == default)
            {
                throw new ArgumentException("A data da venda é inválida.");
            }

            if (sale.Saleitems == null || !sale.Saleitems.Any())
            {
                throw new ArgumentException("A venda deve conter pelo menos um item.");
            }

            if (sale.Saleitems != null)
            {
                foreach (var saleitem in sale.Saleitems)
                {
                    if (saleitem.Amount <= 0)
                    {
                        throw new ArgumentException("A quantidade do item de venda deve ser maior que zero.");
                    }
                }
            }
        }
    }
}

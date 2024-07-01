using Moq;
using XCompany.Services;
using XCompany.Data.Repositories;
using System.Linq.Expressions;
using XCompany.Data.Entities;

namespace XCompany.Tests
{
    /// <summary>
    /// Testes unitários para a classe SaleService.
    /// </summary>
    public class SaleServiceTests
    {
        private readonly Mock<IRepository<Sale>> _repositoryMock;
        private readonly Mock<IRepository<Saleitem>> _saleitemRepositoryMock;
        private readonly ISaleService _saleService;

        public SaleServiceTests()
        {
            _saleitemRepositoryMock = new Mock<IRepository<Saleitem>>();
            _repositoryMock = new Mock<IRepository<Sale>>();
            _saleService = new SaleService(_repositoryMock.Object);
        }

        /// <summary>
        /// Testa se AddAsync adiciona uma venda válida corretamente.
        /// </summary>
        [Fact]
        public async Task AddSaleAsync_ShouldAddSale_WhenSaleIsValid()
        {
            // Arrange
            var sale = new Sale
            {
                SaleDate = DateTime.Now,
                SaleItems = new List<Saleitem>
                {
                    new Saleitem { ProductId = 1, Amount = 2 },
                    new Saleitem { ProductId = 2, Amount = 1 }
                }
            };

            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Sale>())).Returns(Task.CompletedTask);

            // Act
            await _saleService.AddAsync(sale);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(sale), Times.Once);
        }

        /// <summary>
        /// Testa se AddAsync lança uma ArgumentException quando a data da venda é inválida.
        /// </summary>
        [Fact]
        public async Task AddSaleAsync_ShouldThrowArgumentException_WhenSaleDateIsInvalid()
        {
            // Arrange
            var sale = new Sale { SaleDate = DateTime.MinValue }; // Data de venda inválida

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () => await _saleService.AddAsync(sale));
            Assert.Equal("A data da venda é inválida.", exception.Message);
        }

        /// <summary>
        /// Testa se AddAsync lança uma ArgumentException quando a lista de itens da venda está vazia.
        /// </summary>
        [Fact]
        public async Task AddSaleAsync_ShouldThrowArgumentException_WhenSaleItemsAreEmpty()
        {
            // Arrange
            var sale = new Sale { SaleDate = DateTime.Now, SaleItems = new List<Saleitem>() };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () => await _saleService.AddAsync(sale));
            Assert.Equal("A venda deve conter pelo menos um item.", exception.Message);
        }

        /// <summary>
        /// Testa se GetByIdAsync retorna a venda correta quando existe.
        /// </summary>
        [Fact]
        public async Task GetSaleByIdAsync_ShouldReturnSale_WhenSaleExists()
        {
            // Arrange
            var saleId = 1;
            var expectedSale = new Sale { Id = saleId, SaleDate = DateTime.Now };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(saleId)).ReturnsAsync(expectedSale);

            // Act
            var result = await _saleService.GetByIdAsync(saleId);

            // Assert
            Assert.Equal(expectedSale, result);
        }

        /// <summary>
        /// Testa se GetByIdAsync retorna null quando a venda não existe.
        /// </summary>
        [Fact]
        public async Task GetSaleByIdAsync_ShouldReturnNull_WhenSaleDoesNotExist()
        {
            // Arrange
            var saleId = 1;
            _repositoryMock.Setup(repo => repo.GetByIdAsync(saleId)).ReturnsAsync((Sale)null);

            // Act
            var result = await _saleService.GetByIdAsync(saleId);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Testa se GetAllAsync retorna todas as vendas corretamente.
        /// </summary>
        [Fact]
        public async Task GetAllSalesAsync_ShouldReturnAllSales()
        {
            // Arrange
            var sales = new List<Sale>
            {
                new Sale { Id = 1, SaleDate = DateTime.Now },
                new Sale { Id = 2, SaleDate = DateTime.Now }
            };

            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sales);

            // Act
            var result = await _saleService.GetAllAsync();

            // Assert
            Assert.Equal(sales, result);
        }

        /// <summary>
        /// Testa se UpdateAsync atualiza uma venda existente corretamente.
        /// </summary>
        [Fact]
        public async Task UpdateSaleAsync_ShouldUpdateSale_WhenSaleExists()
        {
            // Arrange
            var saleId = 1;
            var saleItem = new Saleitem { ProductId = 1, Amount = 2 };
            var listSaleItems = new List<Saleitem>();
            listSaleItems.Add(saleItem);
            var existingSale = new Sale { Id = saleId, SaleDate = DateTime.Now, SaleItems = listSaleItems };
            var updatedSale = new Sale { Id = saleId, SaleDate = DateTime.Now.AddDays(1), SaleItems = listSaleItems };

            _repositoryMock.Setup(repo => repo.GetByIdAsync(saleId)).ReturnsAsync(existingSale);
            _repositoryMock.Setup(repo => repo.Update(updatedSale)).Returns(Task.CompletedTask);

            // Act
            await _saleService.UpdateAsync(updatedSale);

            // Assert
            _repositoryMock.Verify(repo => repo.Update(It.IsAny<Sale>()), Times.Once);
        }

        /// <summary>
        /// Testa se UpdateAsync lança uma ArgumentException quando a venda não é encontrada.
        /// </summary>
        [Fact]
        public async Task UpdateSaleAsync_ShouldThrowArgumentException_WhenSaleNotFound()
        {
            // Arrange
            var saleId = 1;
            var saleItem = new Saleitem { ProductId = 1, Amount = 2 };
            var listSaleItems = new List<Saleitem>();
            listSaleItems.Add(saleItem);
            var updatedSale = new Sale { Id = saleId, SaleDate = DateTime.Now, SaleItems = listSaleItems };

            _repositoryMock.Setup(repo => repo.GetByIdAsync(saleId)).ReturnsAsync((Sale)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _saleService.UpdateAsync(updatedSale));
            Assert.Equal("Venda não encontrada.", exception.Message);
        }

        /// <summary>
        /// Testa se RemoveAsync remove uma venda existente corretamente.
        /// </summary>
        [Fact]
        public async Task RemoveSaleAsync_ShouldRemoveSale_WhenSaleExists()
        {
            // Arrange
            var saleId = 1;
            var existingSale = new Sale { Id = saleId, SaleDate = DateTime.Now };

            _repositoryMock.Setup(repo => repo.GetByIdAsync(saleId)).ReturnsAsync(existingSale);
            _repositoryMock.Setup(repo => repo.Remove(existingSale));

            // Act
            await _saleService.RemoveAsync(saleId);

            // Assert
            _repositoryMock.Verify(repo => repo.Remove(existingSale), Times.Once);
        }

        /// <summary>
        /// Testa se RemoveAsync lança uma ArgumentException quando a venda não é encontrada.
        /// </summary>
        [Fact]
        public async Task RemoveSaleAsync_ShouldThrowArgumentException_WhenSaleNotFound()
        {
            // Arrange
            var saleId = 1;
            var existingSale = new Sale { Id = saleId, SaleDate = DateTime.Now };

            _repositoryMock.Setup(repo => repo.GetByIdAsync(saleId)).ReturnsAsync((Sale)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _saleService.RemoveAsync(saleId));
            Assert.Equal("Venda não encontrada.", exception.Message);
        }

        /// <summary>
        /// Testa se GetAllWithSaleItemsAndCustomerAsync retorna todas as vendas com itens de venda e cliente corretamente.
        /// </summary>
        [Fact]
        public async Task GetAllWithSaleItemsAndCustomerAsync_ShouldReturnSalesWithItemsAndCustomer()
        {
            // Arrange
            var saleItems = new List<Saleitem>
            {
                new Saleitem { Id = 1, SaleId = 1, Amount = 2 },
                new Saleitem { Id = 2, SaleId = 1, Amount = 3 },
                new Saleitem { Id = 3, SaleId = 2, Amount = 1 }
            };

            var customer1 = new Customer
            {
                Id = 1,
                Name = "John Doe"
            };

            var customer2 = new Customer
            {
                Id = 2,
                Name = "John Smith"
            };

            var sales = new List<Sale>
            {
                new Sale { Id = 1, CustomerId = 1, SaleDate = new DateTime(2023, 6, 1), Customer = customer1, SaleItems = saleItems.Where(x => x.SaleId == 1).ToList() },
                new Sale { Id = 2, CustomerId = 2, SaleDate = new DateTime(2023, 6, 2), Customer = customer2, SaleItems = saleItems.Where(x => x.SaleId == 2).ToList() }
            };

            _repositoryMock.Setup(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Sale, object>>[]>()))
                .ReturnsAsync(sales);

            // Act
            var result = await _saleService.GetAllWithSaleItemsAndCustomerAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            // Assert para a primeira venda
            var firstSale = result.First();
            Assert.Equal(2, firstSale.SaleItems.Count());
            Assert.NotNull(firstSale.Customer);
            Assert.Equal("John Doe", firstSale.Customer.Name); // Garante que os detalhes do Cliente estão corretos

            // Assert para a segunda venda
            var secondSale = result.Last();
            Assert.Equal(1, secondSale.SaleItems.Count());
            Assert.NotNull(secondSale.Customer);
            Assert.Equal("John Smith", secondSale.Customer.Name); // Garante que os detalhes do Cliente estão corretos

            // Verifica a chamada do método do repositório
            _repositoryMock.Verify(repo => repo.GetAllWithIncludeAsync(
                It.IsAny<Expression<Func<Sale, object>>[]>()), Times.Once);
        }
    }
}

using Moq;
using XCompany.Data.Repositories;
using XCompany.Services;
using XCompany.Data.Entities;

namespace XCompany.Tests
{
    /// <summary>
    /// Testes unitários para a classe ProductService.
    /// </summary>
    public class ProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _repositoryMock;
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Product>>();
            _productService = new ProductService(_repositoryMock.Object);
        }

        /// <summary>
        /// Testa se GetByIdAsync retorna o produto correto quando existe.
        /// </summary>
        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var expectedProduct = new Product { Id = productId, Name = "Test Product" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(expectedProduct);

            // Act
            var product = await _productService.GetByIdAsync(productId);

            // Assert
            Assert.Equal(expectedProduct, product);
        }

        /// <summary>
        /// Testa se GetByIdAsync retorna null quando o produto não existe.
        /// </summary>
        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 1;
            _repositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync((Product)null);

            // Act
            var product = await _productService.GetByIdAsync(productId);

            // Assert
            Assert.Null(product);
        }

        /// <summary>
        /// Testa se GetAllAsync retorna todos os produtos corretamente.
        /// </summary>
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllAsync();

            // Assert
            Assert.Equal(products, result);
        }

        /// <summary>
        /// Testa se AddAsync adiciona um produto válido corretamente.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldAddProduct_WhenProductIsValid()
        {
            // Arrange
            var product = new Product { Name = "Test Product", Description = "Description", Price = 10.5m, Stock = 100 };

            // Act
            await _productService.AddAsync(product);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(product), Times.Once);
        }

        /// <summary>
        /// Testa se AddAsync lança uma ArgumentException quando o nome do produto é inválido (vazio).
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenProductNameIsInvalid()
        {
            // Arrange
            var invalidProduct = new Product { Name = "", Description = "Description", Price = 10.5m, Stock = 100 };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(invalidProduct));
            Assert.Equal("O nome do produto é obrigatório.", exception.Message);
        }

        /// <summary>
        /// Testa se UpdateAsync atualiza um produto existente corretamente.
        /// </summary>
        [Fact]
        public async Task UpdateAsync_ShouldUpdateProduct_WhenProductIsValid()
        {
            // Arrange
            var productId = 1;
            var existingProduct = new Product { Id = productId, Name = "Existing Product", Description = "Description", Price = 15.75m, Stock = 50 };
            var updatedProduct = new Product { Id = productId, Name = "Updated Product", Description = "Updated Description", Price = 20.5m, Stock = 75 };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(existingProduct);

            // Act
            await _productService.UpdateAsync(updatedProduct);

            // Assert
            _repositoryMock.Verify(repo => repo.Update(It.IsAny<Product>()), Times.Once);
        }

        /// <summary>
        /// Testa se UpdateAsync lança uma ArgumentException quando o produto não existe.
        /// </summary>
        [Fact]
        public async Task UpdateAsync_ShouldThrowArgumentException_WhenProductDoesNotExist()
        {
            // Arrange
            var nonExistingProductId = 1;
            var updatedProduct = new Product { Id = nonExistingProductId, Name = "Updated Product", Description = "Updated Description", Price = 20.5m, Stock = 75 };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(nonExistingProductId)).ReturnsAsync((Product)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _productService.UpdateAsync(updatedProduct));
            Assert.Equal("Produto não encontrado.", exception.Message);
        }

        /// <summary>
        /// Testa se RemoveAsync remove um produto existente corretamente.
        /// </summary>
        [Fact]
        public async Task RemoveAsync_ShouldRemoveProduct_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var existingProduct = new Product { Id = productId, Name = "Existing Product" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(existingProduct);

            // Act
            await _productService.RemoveAsync(productId);

            // Assert
            _repositoryMock.Verify(repo => repo.RemoveAsync(existingProduct), Times.Once);
        }

        /// <summary>
        /// Testa se RemoveAsync lança uma ArgumentException quando o produto não existe.
        /// </summary>
        [Fact]
        public async Task RemoveAsync_ShouldThrowArgumentException_WhenProductDoesNotExist()
        {
            // Arrange
            var nonExistingProductId = 1;
            _repositoryMock.Setup(repo => repo.GetByIdAsync(nonExistingProductId)).ReturnsAsync((Product)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _productService.RemoveAsync(nonExistingProductId));
            Assert.Equal("Produto não encontrado.", exception.Message);
        }

        /// <summary>
        /// Testa se AddAsync lança uma ArgumentException quando o nome do produto é nulo ou vazio.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenProductNameIsNullOrWhitespace()
        {
            // Arrange
            var invalidProduct = new Product { Name = "", Description = "Description", Price = 10.5m, Stock = 100 };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(invalidProduct));
            Assert.Equal("O nome do produto é obrigatório.", exception.Message);
        }

        /// <summary>
        /// Testa se AddAsync lança uma ArgumentException quando a descrição do produto é nula ou vazia.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenProductDescriptionIsNullOrWhitespace()
        {
            // Arrange
            var invalidProduct = new Product { Name = "Test Product", Description = "", Price = 10.5m, Stock = 100 };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(invalidProduct));
            Assert.Equal("A descrição do produto é obrigatória.", exception.Message);
        }

        /// <summary>
        /// Testa se AddAsync lança uma ArgumentException quando o preço do produto é zero.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenProductPriceIsZero()
        {
            // Arrange
            var invalidProductZeroPrice = new Product { Name = "Test Product", Description = "Description", Price = 0, Stock = 100 };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(invalidProductZeroPrice));
            Assert.Equal("O preço do produto deve ser maior que zero.", exception.Message);
        }

        /// <summary>
        /// Testa se AddAsync lança uma ArgumentException quando o preço do produto é negativo.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenProductPriceIsNegative()
        {
            // Arrange
            var invalidProductNegativePrice = new Product { Name = "Test Product", Description = "Description", Price = -10.5m, Stock = 100 };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(invalidProductNegativePrice));
            Assert.Equal("O preço do produto deve ser maior que zero.", exception.Message);
        }

        /// <summary>
        /// Testa se AddAsync lança uma ArgumentException quando o estoque do produto é negativo.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenProductStockIsNegative()
        {
            // Arrange
            var invalidProduct = new Product { Name = "Test Product", Description = "Description", Price = 10.5m, Stock = -10 };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(invalidProduct));
            Assert.Equal("O estoque do produto não pode ser negativo.", exception.Message);
        }
    }
}

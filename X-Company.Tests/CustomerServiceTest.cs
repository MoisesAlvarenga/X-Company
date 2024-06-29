using System.Linq.Expressions;
using Moq;
using XCompany.Services;
using XCompany.Data.Repositories;
using XCompany.Data.Entities;

namespace XCompany.Tests
{
    /// <summary>
    /// Classe de testes para validar o comportamento do serviço de clientes.
    /// </summary>
    public class CustomerServiceTests
    {
        private readonly Mock<IRepository<Customer>> _repositoryMock;
        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Customer>>();
            _customerService = new CustomerService(_repositoryMock.Object);
        }

        /// <summary>
        /// Testa o método GetByIdAsync do serviço de clientes quando um cliente com o ID especificado existe.
        /// </summary>
        [Fact]
        public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
        {
            // Arrange
            var customerId = 1;
            var expectedCustomer = new Customer { Id = customerId, Name = "John Doe" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(expectedCustomer);

            // Act
            var customer = await _customerService.GetByIdAsync(customerId);

            // Assert
            Assert.Equal(expectedCustomer, customer);
        }

        /// <summary>
        /// Testa o método GetAllAsync do serviço de clientes para garantir que todos os clientes sejam retornados corretamente.
        /// </summary>
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe" },
                new Customer { Id = 2, Name = "Jane Smith" }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(customers);

            // Act
            var result = await _customerService.GetAllAsync();

            // Assert
            Assert.Equal(customers, result);
        }

        /// <summary>
        /// Testa o método AddAsync do serviço de clientes para garantir que um cliente válido seja adicionado corretamente.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldAddCustomer_WhenCustomerIsValid()
        {
            // Arrange
            var customer = new Customer { Name = "John Doe", Email = "john.doe@example.com", Phone = "1234567890", Address = "123 Street" };

            // Act
            await _customerService.AddAsync(customer);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(customer), Times.Once);
        }

        /// <summary>
        /// Testa o método AddAsync do serviço de clientes para garantir que uma exceção seja lançada quando o email do cliente já está cadastrado.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenEmailIsAlreadyRegistered()
        {
            // Arrange
            var customer = new Customer { Name = "John Doe", Email = "john.doe@example.com", Phone = "1234567890", Address = "123 Street" };
            var customerList = new List<Customer> { customer };

            _repositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<Customer, bool>>>())).ReturnsAsync(customerList);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _customerService.AddAsync(customer));
            Assert.Equal("Email já cadastrado.", exception.Message);

            // Verifica que o método AddAsync do repositório não foi chamado
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Never);
        }

        /// <summary>
        /// Testa o método AddAsync do serviço de clientes para garantir que uma exceção seja lançada quando o nome do cliente está vazio.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenNameIsEmpty()
        {
            // Arrange
            var invalidCustomer = new Customer { Name = "", Email = "test@example.com", Phone = "1234567890", Address = "123 Street" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _customerService.AddAsync(invalidCustomer));
            Assert.Equal("O nome é obrigatório.", exception.Message);
        }

        /// <summary>
        /// Testa o método AddAsync do serviço de clientes para garantir que uma exceção seja lançada quando o email do cliente é inválido.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenEmailIsInvalid()
        {
            // Arrange
            var invalidCustomer = new Customer { Name = "John Doe", Email = "invalidemail", Phone = "1234567890", Address = "123 Street" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _customerService.AddAsync(invalidCustomer));
            Assert.Equal("Email inválido.", exception.Message);

            // Verifica que o método AddAsync do repositório não foi chamado
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Never);
        }

        /// <summary>
        /// Testa o método AddAsync do serviço de clientes para garantir que uma exceção seja lançada quando o número de telefone do cliente é inválido.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenPhoneIsInvalid()
        {
            // Arrange
            var invalidCustomer = new Customer { Name = "John Doe", Email = "test@example.com", Phone = "abc123", Address = "123 Street" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _customerService.AddAsync(invalidCustomer));
            Assert.Equal("Número de telefone inválido.", exception.Message);

            // Verifica que o método AddAsync do repositório não foi chamado
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Never);
        }

        /// <summary>
        /// Testa o método AddAsync do serviço de clientes para garantir que uma exceção seja lançada quando o endereço do cliente está vazio.
        /// </summary>
        [Fact]
        public async Task AddAsync_ShouldThrowArgumentException_WhenAddressIsEmpty()
        {
            // Arrange
            var invalidCustomer = new Customer { Name = "John Doe", Email = "test@example.com", Phone = "1234567890", Address = "" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _customerService.AddAsync(invalidCustomer));
            Assert.Equal("O endereço é obrigatório.", exception.Message);

            // Verifica que o método AddAsync do repositório não foi chamado
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Never);
        }

        /// <summary>
        /// Testa o método UpdateAsync do serviço de clientes para garantir que um cliente existente seja atualizado corretamente.
        /// </summary>
        [Fact]
        public async Task UpdateAsync_ShouldUpdateCustomer_WhenCustomerIsValid()
        {
            // Arrange
            var customerId = 1;
            var existingCustomer = new Customer { Id = customerId, Name = "John Doe", Email = "john.doe@example.com", Phone = "1234567890", Address = "123 Street" };
            var updatedCustomer = new Customer { Id = customerId, Name = "John Smith", Email = "john.doe@example.com", Phone = "0987654321", Address = "456 Avenue" };
            var customerList = new List<Customer> { existingCustomer };

            _repositoryMock.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(existingCustomer);
            _repositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<Customer, bool>>>())).ReturnsAsync(customerList);

            // Act
            await _customerService.UpdateAsync(updatedCustomer);

            // Assert
            _repositoryMock.Verify(repo => repo.Update(It.IsAny<Customer>()), Times.Once);
        }

        /// <summary>
        /// Testa o método UpdateAsync do serviço de clientes para garantir que uma exceção seja lançada quando o cliente não é encontrado.
        /// </summary>
        [Fact]
        public async Task UpdateAsync_ShouldThrowArgumentException_WhenCustomerNotFound()
        {
            // Arrange
            var updatedCustomer = new Customer { Id = 1, Name = "John Smith", Email = "john.smith@example.com", Phone = "0987654321", Address = "456 Avenue" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(updatedCustomer.Id)).ReturnsAsync((Customer)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _customerService.UpdateAsync(updatedCustomer));
            Assert.Equal("Cliente não encontrado.", exception.Message);

            _repositoryMock.Verify(repo => repo.Update(It.IsAny<Customer>()), Times.Never);
        }

        /// <summary>
        /// Testa o método UpdateAsync do serviço de clientes para garantir que uma exceção seja lançada quando o email do cliente já está cadastrado em outro cliente.
        /// </summary>
        [Fact]
        public async Task UpdateAsync_ShouldThrowArgumentException_WhenEmailIsAlreadyRegistered()
        {
            // Arrange
            var customerId = 1;
            var existingCustomer = new Customer { Id = customerId, Name = "John Doe", Email = "john.doe@example.com", Phone = "1234567890", Address = "123 Street" };
            var updatedCustomer = new Customer { Id = customerId, Name = "John Smith", Email = "john.smith@example.com", Phone = "0987654321", Address = "456 Avenue" };
            var otherCustomerWithSameEmail = new Customer { Id = 2, Email = "john.smith@example.com" };
            var customerList = new List<Customer> { otherCustomerWithSameEmail };

            _repositoryMock.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(existingCustomer);
            _repositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<Customer, bool>>>())).ReturnsAsync(customerList);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _customerService.UpdateAsync(updatedCustomer));
            Assert.Equal("Email já cadastrado.", exception.Message);
        }

        /// <summary>
        /// Testa o método RemoveAsync do serviço de clientes para garantir que um cliente existente seja removido corretamente.
        /// </summary>
        [Fact]
        public async Task RemoveAsync_ShouldRemoveCustomer_WhenCustomerExists()
        {
            // Arrange
            var customerId = 1;
            var existingCustomer = new Customer { Id = customerId, Name = "John Doe" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(existingCustomer);
            _repositoryMock.Setup(repo => repo.RemoveAsync(existingCustomer));

            // Act
            await _customerService.RemoveAsync(customerId);

            // Assert
            _repositoryMock.Verify(repo => repo.RemoveAsync(existingCustomer), Times.Once);
        }

        /// <summary>
        /// Testa o método RemoveAsync do serviço de clientes para garantir que uma exceção seja lançada quando o cliente não é encontrado.
        /// </summary>
        [Fact]
        public async Task RemoveAsync_ShouldThrowArgumentException_WhenCustomerNotFound()
        {
            // Arrange
            var customerId = 1;
            _repositoryMock.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync((Customer)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _customerService.RemoveAsync(customerId));
            Assert.Equal("Cliente não encontrado.", exception.Message);
        }
    }
}

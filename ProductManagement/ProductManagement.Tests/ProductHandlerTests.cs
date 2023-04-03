using Moq;
using ProductManagement.Domain.Commands.Products;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Handlers;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Tests
{
    [TestFixture]
    public class ProductHandlerTests
    {
        private Mock<IProductRepository> _productRepositoryMock;
        private ProductHandler _productHandler;

        [SetUp]
        public void Setup()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productHandler = new ProductHandler(_productRepositoryMock.Object);
        }

        [Test]
        public void CreateProductCommand_ValidCommand_ReturnsSuccessfulResult()
        {
            // Arrange
            var createProductCommand = new CreateProductCommand("Product", "Description", 10);

            // Act
            var result = _productHandler.Handler(createProductCommand);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Produto criado com sucesso", result.Message);
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void CreateProductCommand_InvalidCommand_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var createProductCommand = new CreateProductCommand("", "", 0);

            // Act
            var result = _productHandler.Handler(createProductCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Não é possível criar o produto", result.Message);
            Assert.IsNotEmpty(createProductCommand.Notifications);
        }

        [Test]
        public void RemoveProductCommand_ValidCommand_ReturnsSuccessfulResult()
        {
            // Arrange
            var productId = Guid.NewGuid();
            _productRepositoryMock.Setup(x => x.GetById(productId)).ReturnsAsync(new Product(productId, "Product", "Description", 10));

            var removeProductCommand = new RemoveProductCommand(productId);

            // Act
            var result = _productHandler.Handler(removeProductCommand);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Produto removido com sucesso", result.Message);
        }

        [Test]
        public void RemoveProductCommand_InvalidCommand_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var removeProductCommand = new RemoveProductCommand(Guid.Empty);

            // Act
            var result = _productHandler.Handler(removeProductCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Não é possível remover o produto", result.Message);
            Assert.IsNotEmpty(removeProductCommand.Notifications);
        }

        [Test]
        public void UpdateProductCommand_ValidCommand_ReturnsSuccessfulResult()
        {
            // Arrange
            var productId = Guid.NewGuid();
            _productRepositoryMock.Setup(x => x.GetById(productId)).ReturnsAsync(new Product(productId, "Product", "Description", 10));

            var updateProductCommand = new UpdateProductCommand(productId, "New Product", "New Description", 20);

            // Act
            var result = _productHandler.Handler(updateProductCommand);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Produto atualizado com sucesso", result.Message);
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void UpdateProductCommand_InvalidCommand_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var updateProductCommand = new UpdateProductCommand(Guid.Empty, "", "", 0);

            // Act
            var result = _productHandler.Handler(updateProductCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Não é possível atualizar o produto", result.Message);
            Assert.IsNotEmpty(updateProductCommand.Notifications);
        }
    }


}

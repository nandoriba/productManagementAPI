using Moq;
using ProductManagement.Domain.Commands.AssociateProductsWithCategories;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Handlers;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Tests
{
    [TestFixture]
    public class AssociateProductWithCategoryHandlerTests
    {
        private Mock<IAssociateProductWithCategoryRepository> _repositoryMock;
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private Mock<IProductRepository> _productRepositoryMock;
        private AssociateProductWithCategoryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IAssociateProductWithCategoryRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _handler = new AssociateProductWithCategoryHandler(_repositoryMock.Object, _categoryRepositoryMock.Object, _productRepositoryMock.Object);
        }

        [Test]
        public void CreateAssociateProductWithCategoryCommand_ValidCommand_ReturnsSuccessfulResult()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            _categoryRepositoryMock.Setup(x => x.GetById(categoryId))
                .ReturnsAsync(new Category(categoryId, "Category"));

            _productRepositoryMock.Setup(x => x.GetById(productId))
                .ReturnsAsync(new Product(productId, "Product", "Description", 10));

            var createCommand = new CreateAssociateProductWithCategoryCommand(categoryId, productId);

            // Act
            var result = _handler.Handler(createCommand);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Associação entre produto e categoria criada com sucesso", result.Message);
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void CreateAssociateProductWithCategoryCommand_InvalidCommand_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var createCommand = new CreateAssociateProductWithCategoryCommand(Guid.Empty, Guid.Empty);

            // Act
            var result = _handler.Handler(createCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Não é possível criar a associação entre produto e categoria", result.Message);
            Assert.IsNotEmpty(createCommand.Notifications);
        }

        [Test]
        public void CreateAssociateProductWithCategoryCommand_CategoryNotFound_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            _categoryRepositoryMock.Setup(x => x.GetById(categoryId))
                .ReturnsAsync((Category)null);

            _productRepositoryMock.Setup(x => x.GetById(productId))
                .ReturnsAsync(new Product(productId, "Product", "Description", 10));

            var createCommand = new CreateAssociateProductWithCategoryCommand(categoryId, productId);

            // Act
            var result = _handler.Handler(createCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Categoria não encontrada", result.Message);
            Assert.IsEmpty(createCommand.Notifications);
        }

        [Test]
        public void CreateAssociateProductWithCategoryCommand_ProductNotFound_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            _categoryRepositoryMock.Setup(x => x.GetById(categoryId))
                .ReturnsAsync(new Category(categoryId, "Category"));

            _productRepositoryMock.Setup(x => x.GetById(productId))
                .ReturnsAsync((Product)null);

            var createCommand = new CreateAssociateProductWithCategoryCommand(categoryId, productId);

            // Act
            var result = _handler.Handler(createCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Produto não encontrado", result.Message);
            Assert.IsEmpty(createCommand.Notifications);
        }

        [Test]
        public void RemoveAssociateProductWithCategoryCommand_ValidCommand_ReturnsSuccessfulResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repositoryMock.Setup(x => x.GetById(id))
                .ReturnsAsync(new AssociateProductWithCategory(id, Guid.NewGuid(), Guid.NewGuid()));

            var removeCommand = new RemoveAssociateProductWithCategoryCommand(id);

            // Act
            var result = _handler.Handler(removeCommand);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Associação entre produto e categoria removida com sucesso", result.Message);
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void RemoveAssociateProductWithCategoryCommand_InvalidCommand_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var removeCommand = new RemoveAssociateProductWithCategoryCommand(Guid.Empty);

            // Act
            var result = _handler.Handler(removeCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Não é possível remover a associação entre produto e categoria", result.Message);
            Assert.IsNotEmpty(removeCommand.Notifications);
        }

        [Test]
        public void RemoveAssociateProductWithCategoryCommand_AssociationNotFound_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repositoryMock.Setup(x => x.GetById(id)).ReturnsAsync((AssociateProductWithCategory)null);

            var removeCommand = new RemoveAssociateProductWithCategoryCommand(id);

            // Act
            var result = _handler.Handler(removeCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Associação entre produto e categoria não encontrada", result.Message);
            Assert.IsEmpty(removeCommand.Notifications);
        }
    }
}

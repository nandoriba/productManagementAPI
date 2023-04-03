using Moq;
using ProductManagement.Domain.Commands.Categories;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Handlers;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Tests
{
    [TestFixture]
    public class CategoryHandlerTests
    {
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private CategoryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _handler = new CategoryHandler(_categoryRepositoryMock.Object);
        }

        [Test]
        public void CreateCategoryCommand_ValidCommand_ReturnsSuccessfulResult()
        {
            // Arrange
            var createCommand = new CreateCategoryCommand("Category");

            // Act
            var result = _handler.Handler(createCommand);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Categoria cadastrada com sucesso", result.Message);
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void CreateCategoryCommand_InvalidCommand_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var createCommand = new CreateCategoryCommand("");

            // Act
            var result = _handler.Handler(createCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Não é possível criar a categoria", result.Message);
            Assert.IsNotEmpty(createCommand.Notifications);
        }

        [Test]
        public void RemoveCategoryCommand_ValidCommand_ReturnsSuccessfulResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _categoryRepositoryMock.Setup(x => x.GetById(id))
                .ReturnsAsync(new Category(id, "Category"));

            var removeCommand = new RemoveCategoryCommand(id);

            // Act
            var result = _handler.Handler(removeCommand);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Categoria removida com sucesso", result.Message);
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void RemoveCategoryCommand_InvalidCommand_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var removeCommand = new RemoveCategoryCommand(Guid.Empty);

            // Act
            var result = _handler.Handler(removeCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Não é possível remover a categoria", result.Message);
            Assert.IsNotEmpty(removeCommand.Notifications);
        }

        [Test]
        public void RemoveCategoryCommand_CategoryNotFound_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _categoryRepositoryMock.Setup(x => x.GetById(id))
                .ReturnsAsync((Category)null);

            var removeCommand = new RemoveCategoryCommand(id);

            // Act
            var result = _handler.Handler(removeCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Categoria não encontrada", result.Message);
            Assert.IsEmpty(removeCommand.Notifications);
        }

        [Test]
        public void UpdateCategoryCommand_ValidCommand_ReturnsSuccessfulResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _categoryRepositoryMock.Setup(x => x.GetById(id))
                .ReturnsAsync(new Category(id, "Category"));

            var updateCommand = new UpdateCategoryCommand(id, "New Category");

            // Act
            var result = _handler.Handler(updateCommand);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Categoria atualizada com sucesso", result.Message);
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void UpdateCategoryCommand_InvalidCommand_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var updateCommand = new UpdateCategoryCommand(Guid.Empty, "");

            // Act
            var result = _handler.Handler(updateCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Não é possível atualizar a categoria", result.Message);
            Assert.IsNotEmpty(updateCommand.Notifications);
        }

        [Test]
        public void UpdateCategoryCommand_CategoryNotFound_ReturnsUnsuccessfulResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _categoryRepositoryMock.Setup(x => x.GetById(id)).ReturnsAsync((Category)null);

            var updateCommand = new UpdateCategoryCommand(id, "New Category");

            // Act
            var result = _handler.Handler(updateCommand);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Categoria não encontrada", result.Message);
            Assert.IsEmpty(updateCommand.Notifications);
        }
    }
}

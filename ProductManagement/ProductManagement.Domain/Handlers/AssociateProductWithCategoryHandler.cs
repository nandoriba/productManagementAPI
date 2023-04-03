using Flunt.Notifications;
using ProductManagement.Domain.Commands;
using ProductManagement.Domain.Commands.AssociateProductsWithCategories;
using ProductManagement.Domain.Commands.Contracts;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Handlers.Contracts;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Domain.Handlers
{
    public class AssociateProductWithCategoryHandler : Notifiable<Notification>,
    IHandler<CreateAssociateProductWithCategoryCommand>,
    IHandler<RemoveAssociateProductWithCategoryCommand>
    {
        private readonly IAssociateProductWithCategoryRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public AssociateProductWithCategoryHandler(IAssociateProductWithCategoryRepository repository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public ICommandResult Handler(CreateAssociateProductWithCategoryCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Não é possível criar a associação entre produto e categoria", command.Notifications);
            }

            var category = _categoryRepository.GetById(command.CategoryId).GetAwaiter().GetResult();
            if (category is null)
            {
                return new GenericCommandsResult(false, "Categoria não encontrada", command.Notifications);
            }

            var product = _productRepository.GetById(command.ProductId).GetAwaiter().GetResult();
            if (product is null)
            {
                return new GenericCommandsResult(false, "Produto não encontrado", command.Notifications);
            }

            var associateProductWithCategory = new AssociateProductWithCategory(Guid.NewGuid(), category.Id, product.Id);
            _repository.Add(associateProductWithCategory);

            return new GenericCommandsResult(true, "Associação entre produto e categoria criada com sucesso", associateProductWithCategory);
        }

        public ICommandResult Handler(RemoveAssociateProductWithCategoryCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Não é possível remover a associação entre produto e categoria", command.Notifications);
            }

            var associateProductWithCategory = _repository.GetById(command.Id).GetAwaiter().GetResult();
            if (associateProductWithCategory is null)
            {
                return new GenericCommandsResult(false, "Associação entre produto e categoria não encontrada", command.Notifications);
            }

            _repository.Remove(associateProductWithCategory);

            return new GenericCommandsResult(true, "Associação entre produto e categoria removida com sucesso", associateProductWithCategory);
        }
    }
}

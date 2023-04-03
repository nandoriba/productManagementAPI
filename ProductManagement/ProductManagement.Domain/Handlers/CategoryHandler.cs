using Flunt.Notifications;
using ProductManagement.Domain.Commands;
using ProductManagement.Domain.Commands.Categories;
using ProductManagement.Domain.Commands.Contracts;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Handlers.Contracts;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Domain.Handlers
{
    public class CategoryHandler : Notifiable<Notification>,
        IHandler<CreateCategoryCommand>,
        IHandler<RemoveCategoryCommand>,
        IHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICommandResult Handler(CreateCategoryCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possível criar a categoria",
                    command.Notifications);
            }

            var category = command.ToCategory();
            _categoryRepository.Add(category);

            return new GenericCommandsResult(true, "Categoria cadastrada com sucesso", category);
        }

        public ICommandResult Handler(RemoveCategoryCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possível remover a categoria",
                    command.Notifications);
            }

            var category = _categoryRepository.GetById(command.Id).GetAwaiter().GetResult();

            if (category is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Categoria não encontrada",
                    command.Notifications);
            }

            category.RemoveLogic();
            _categoryRepository.Update(category);

            return new GenericCommandsResult(true, "Categoria removida com sucesso", category);
        }

        public ICommandResult Handler(UpdateCategoryCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possível atualizar a categoria",
                    command.Notifications);
            }

            var category = _categoryRepository.GetById(command.Id).GetAwaiter().GetResult();
           
            if (category is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Categoria não encontrada",
                    command.Notifications);
            }

            var upCategory = new Category(
                id: command.Id,
                name: command.Name
                );

            _categoryRepository.Update(upCategory);

            return new GenericCommandsResult(true, "Categoria atualizada com sucesso", upCategory);
        }
    }
}

using Flunt.Notifications;
using ProductManagement.Domain.Commands;
using ProductManagement.Domain.Commands.Contracts;
using ProductManagement.Domain.Commands.Products;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Handlers.Contracts;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Domain.Handlers
{
    public class ProductHandler : Notifiable<Notification>,
        IHandler<CreateProductCommand>,
        IHandler<RemoveProductCommand>,
        IHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICommandResult Handler(CreateProductCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Não é possível criar o produto", command.Notifications);
            }

            var product = new Product(
                Guid.NewGuid(),
                command.Name,
                command.Description,
                command.Price
            );
            _productRepository.Add(product);

            return new GenericCommandsResult(true, "Produto criado com sucesso", product);
        }

        public ICommandResult Handler(RemoveProductCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Não é possível remover o produto", command.Notifications);
            }

            var product = _productRepository.GetById(command.Id).GetAwaiter().GetResult();
            if (product is null)
            {
                return new GenericCommandsResult(false, "Produto não encontrado", command.Notifications);
            }

            product.RemoveLogic();
            _productRepository.Update(product);

            return new GenericCommandsResult(true, "Produto removido com sucesso", product);
        }

        public ICommandResult Handler(UpdateProductCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Não é possível atualizar o produto", command.Notifications);
            }

            var product = _productRepository.GetById(command.Id).GetAwaiter().GetResult();
            if (product is null)
            {
                return new GenericCommandsResult(false, "Produto não encontrado", command.Notifications);
            }

            var productUpdate = new Product(
                id: command.Id,
                name: command.Name,
                description: command.Description,
                price: command.Price
            );

            _productRepository.Update(productUpdate);

            return new GenericCommandsResult(true, "Produto atualizado com sucesso", productUpdate);
        }
    }
}

using Flunt.Notifications;
using Flunt.Validations;
using ProductManagement.Domain.Commands.Contracts;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Domain.Commands.AssociateProductsWithCategories
{
    public class CreateAssociateProductWithCategoryCommand :  Notifiable<Notification>, ICommand
    {
        public CreateAssociateProductWithCategoryCommand() { }

        public CreateAssociateProductWithCategoryCommand(Guid categoryId, Guid productId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }

        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(CategoryId, "CategoryId", "O Id da categoria precisa ser preenchido")
                .IsNotEmpty(ProductId, "ProductId", "O Id do produto precisa ser preenchido")
            );
        }
    }

}

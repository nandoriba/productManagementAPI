using Flunt.Notifications;
using Flunt.Validations;
using ProductManagement.Domain.Commands.Contracts;

namespace ProductManagement.Domain.Commands.AssociateProductsWithCategories
{
    public class RemoveAssociateProductWithCategoryCommand : Notifiable<Notification>, ICommand
    {
        public RemoveAssociateProductWithCategoryCommand() { }

        public RemoveAssociateProductWithCategoryCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Id, "Id", "O Id da associação precisa ser preenchido")
            );
        }
    }

}

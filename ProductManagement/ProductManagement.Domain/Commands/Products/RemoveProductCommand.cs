using Flunt.Notifications;
using Flunt.Validations;
using ProductManagement.Domain.Commands.Contracts;

namespace ProductManagement.Domain.Commands.Products
{
    public class RemoveProductCommand : Notifiable<Notification>, ICommand
    {
        public RemoveProductCommand() { }

        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Id, "Id", "O Campo Id precisa ser preenchido")
                );
        }       
    }
}

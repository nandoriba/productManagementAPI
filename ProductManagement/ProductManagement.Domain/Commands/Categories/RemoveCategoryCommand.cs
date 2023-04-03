using Flunt.Notifications;
using Flunt.Validations;
using ProductManagement.Domain.Commands.Contracts;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Domain.Commands.Categories
{
    public class RemoveCategoryCommand : Notifiable<Notification>, ICommand
    {
        public RemoveCategoryCommand(Guid id)
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

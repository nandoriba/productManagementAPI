using Flunt.Notifications;
using Flunt.Validations;
using ProductManagement.Domain.Commands.Contracts;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Domain.Commands.Categories
{
    public class UpdateCategoryCommand : Notifiable<Notification>, ICommand
    {
        public UpdateCategoryCommand() { }

        public UpdateCategoryCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Name, 3, "Nome", "O Nome da categoria precisa ter pelo menos 3 caracteres")
                );
        }
    }
}

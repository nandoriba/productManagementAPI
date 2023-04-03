using Flunt.Notifications;
using Flunt.Validations;
using ProductManagement.Domain.Commands.Contracts;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Domain.Commands.Categories
{
    public class CreateCategoryCommand : Notifiable<Notification>, ICommand
    {
        public CreateCategoryCommand() { }

        public CreateCategoryCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Name, 3, "Nome", "O Nome da categoria precisa ter pelo menos 3 caracteres")
                );
        }

        public Category ToCategory()
        {
            var id = Guid.NewGuid();
            return new Category(id, Name);
        }
    }
}

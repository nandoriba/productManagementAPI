using Flunt.Notifications;
using Flunt.Validations;
using ProductManagement.Domain.Commands.Contracts;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Domain.Commands.Products
{
    public class UpdateProductCommand : Notifiable<Notification>, ICommand
    {
        public UpdateProductCommand() { }

        public UpdateProductCommand(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Name, 3, "Nome", "O Nome do produto precisa ter pelo menos 3 caracteres")
                .IsGreaterThan(Description, 3, "Descricao", "A descricao do produto precisa ter pelo menos 3 caracteres")
                .IsGreaterThan(Price, 0, "Preco", "O preco do produto precisa ser maior que 0")
                );
        }        
    }
}

using Flunt.Notifications;
using Flunt.Validations;
using ProductManagement.Domain.Commands.Contracts;

namespace ProductManagement.Domain.Commands.Products
{
    public class CreateProductCommand : Notifiable<Notification>, ICommand
    {
        public CreateProductCommand() { }

        public CreateProductCommand(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Name, 3, "Nome", "O Nome do Produto precisa ter pelo menos 3 caracteres")
                .IsGreaterThan(Description, 3, "Descricao", "A Descrição precisa ter pelo menos 3 caracteres")
                .IsGreaterThan(Price, 0, "Preco", "O Preço precisa ser maior que zero")
                );
        }  
    }
}

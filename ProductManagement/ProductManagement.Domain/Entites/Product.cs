using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Domain.Entites
{
    public class Product : Entity
    {
        public Product(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Status = State.Active.Id;
        }

        protected Product()
        { }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Status { get; private set; }

        public void RemoveLogic()
        {
            if (Status == State.Active.Id)
            {
                Status = State.Inactive.Id;
            }
        }
    }
}

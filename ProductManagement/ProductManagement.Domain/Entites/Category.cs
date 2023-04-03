using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Domain.Entites
{
    public class Category : Entity
    {
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
            Status = State.Active.Id;
        }
        protected Category() 
        { }

        public string Name { get; private set; }
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

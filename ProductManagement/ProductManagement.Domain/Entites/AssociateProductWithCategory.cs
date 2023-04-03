namespace ProductManagement.Domain.Entites
{
    public class AssociateProductWithCategory : Entity
    {
        public AssociateProductWithCategory(Guid id, Guid categoryId, Guid productId)
        {
            Id = id;
            CategoryId = categoryId;
            ProductId = productId;
        }

        protected AssociateProductWithCategory()
        { }

        public Guid CategoryId { get; private set; }
        public Guid ProductId { get; private set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }

    }
}

using ProductManagement.Domain.Entites;

namespace ProductManagement.Domain.Queries
{
    public interface IAssociateProductWithCategoryQueries
    {
        Task<IEnumerable<Product>> GetProductIdByCategoryId(Guid categoryId);        
    }
}

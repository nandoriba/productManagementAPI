using ProductManagement.Domain.Entites;
using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Domain.Queries
{
    public interface IProductQueries
    {
        Task<Product> GetById(Guid id);
        Task<IEnumerable<Product>> GetAllStatus(State status);
        Task<IEnumerable<Product>> GetAllByDescription(string description);                
    }
}

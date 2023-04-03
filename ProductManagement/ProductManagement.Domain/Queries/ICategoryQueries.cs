using ProductManagement.Domain.Entites;
using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Domain.Queries
{
    public interface ICategoryQueries
    {
        Task<Category> GetById(Guid id);
        Task<IEnumerable<Category>> GetAllStatus(State status);
        Task<IEnumerable<Category>> GetAllByName(string name);
    }
}

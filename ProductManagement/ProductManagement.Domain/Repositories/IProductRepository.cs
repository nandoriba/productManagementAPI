using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories.Contract;

namespace ProductManagement.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void Update(Product item);
    }
}

using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories.Contract;

namespace ProductManagement.Domain.Repositories
{
    public interface ICategoryRepository: IRepositoryBase<Category>
    {
        void Update(Category item);
    }
}

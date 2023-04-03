using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories.Contract;

namespace ProductManagement.Domain.Repositories
{
    public interface IAssociateProductWithCategoryRepository: IRepositoryBase<AssociateProductWithCategory>
    {
        void Remove(AssociateProductWithCategory item);
    }
}

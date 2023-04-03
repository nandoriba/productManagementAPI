using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories;
using System.Linq.Expressions;

namespace ProductManagement.Infrastructure.Repositories
{
    public class AssociateProductWithCategoryRepository : IAssociateProductWithCategoryRepository
    {
        private readonly DbContext _dbContext;

        public AssociateProductWithCategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(AssociateProductWithCategory item)
        {
            _dbContext.Set<AssociateProductWithCategory>().Add(item);
        }

        public async Task<AssociateProductWithCategory> GetById(Guid id)
        {
            return await _dbContext.Set<AssociateProductWithCategory>().FindAsync(id);
        }

        public async Task<IEnumerable<AssociateProductWithCategory>> GetAll()
        {
            return await _dbContext.Set<AssociateProductWithCategory>().ToListAsync();
        }

        public void Update(AssociateProductWithCategory item)
        {
            _dbContext.Set<AssociateProductWithCategory>().Update(item);
        }

        public void Remove(AssociateProductWithCategory item)
        {
            _dbContext.Set<AssociateProductWithCategory>().Remove(item);
        }

        public async Task<int> Count(Expression<Func<AssociateProductWithCategory, bool>> predicate)
        {
            return await _dbContext.Set<AssociateProductWithCategory>().CountAsync(predicate);
        }

        public async Task<bool> Exists(Expression<Func<AssociateProductWithCategory, bool>> predicate)
        {
            return await _dbContext.Set<AssociateProductWithCategory>().AnyAsync(predicate);
        }
    }

}

using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _dbContext;

        public CategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Category item)
        {
            _dbContext.Set<Category>().Add(item);
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _dbContext.Set<Category>().FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Set<Category>().ToListAsync();
        }

        public void Update(Category item)
        {
            _dbContext.Set<Category>().Update(item);
        }
    }

}

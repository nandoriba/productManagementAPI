using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories;
using ProductManagement.Domain.ValueObjects;
using ProductManagement.Infrastructure.Context;

namespace ProductManagement.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dbContext;

        public CategoryRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Category item)
        {
            _dbContext.Set<Category>().Add(item);
            _dbContext.SaveChanges();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _dbContext.Set<Category>().FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext
                .Category
                .AsNoTracking()
                .Where(w => w.Status == State.Active.Id)
                .ToListAsync();
        }

        public void Update(Category item)
        {
            var existing = _dbContext.Set<Category>().Find(item.Id);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(item);
                _dbContext.SaveChanges();
            }
        }
    }

}

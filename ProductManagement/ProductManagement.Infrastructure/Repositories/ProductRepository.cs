using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories;
using ProductManagement.Domain.ValueObjects;
using ProductManagement.Infrastructure.Context;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dbContext)
        {
            _dbContext = dbContext;            
        }

        public void Add(Product item)
        {
            _dbContext.Set<Product>().Add(item);
            _dbContext.SaveChanges();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _dbContext.Set<Product>().FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext
                .Product
                .AsNoTracking()
                .Where(w => w.Status == State.Active.Id)
                .ToListAsync();
        }

        public void Update(Product item)
        {
            var existing = _dbContext.Set<Product>().Find(item.Id);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(item);
                _dbContext.SaveChanges();
            }
        }
    }
}

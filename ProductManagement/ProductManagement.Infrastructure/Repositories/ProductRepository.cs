using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _dbContext;

        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Product item)
        {
            _dbContext.Set<Product>().Add(item);
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _dbContext.Set<Product>().FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Set<Product>().ToListAsync();
        }

        public void Update(Product item)
        {
            _dbContext.Set<Product>().Update(item);
        }
    }
}

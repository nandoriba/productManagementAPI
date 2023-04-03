using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Repositories;
using ProductManagement.Infrastructure.Context;
using System.Linq.Expressions;

namespace ProductManagement.Infrastructure.Repositories
{
    public class AssociateProductWithCategoryRepository : IAssociateProductWithCategoryRepository
    {
        private readonly DataContext _context;

        public AssociateProductWithCategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AssociateProductWithCategory> GetById(Guid id)
        {
            return await _context.Set<AssociateProductWithCategory>().FindAsync(id);
        }

        public async Task<IEnumerable<AssociateProductWithCategory>> GetAll()
        {
            return await _context.Set<AssociateProductWithCategory>().ToListAsync();
        }

        public void Add(AssociateProductWithCategory item)
        {
            _context.Set<AssociateProductWithCategory>().Add(item);
            _context.SaveChanges();
        }

        public void Update(AssociateProductWithCategory item)
        {
            _context.Set<AssociateProductWithCategory>().Update(item);
            _context.SaveChanges();
        }

        public void Remove(AssociateProductWithCategory item)
        {
            _context.Set<AssociateProductWithCategory>().Remove(item);
            _context.SaveChanges();
        }

        public async Task<int> Count(Expression<Func<AssociateProductWithCategory, bool>> predicate)
        {
            return await _context.Set<AssociateProductWithCategory>().CountAsync(predicate);
        }

        public async Task<bool> Exists(Expression<Func<AssociateProductWithCategory, bool>> predicate)
        {
            return await _context.Set<AssociateProductWithCategory>().AnyAsync(predicate);
        }
    }

}

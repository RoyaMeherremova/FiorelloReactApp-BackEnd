using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Product> _entities;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Product>();
        }

        public async Task CreateAsync(Product entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> expression = null)
        {
            var query = _entities.AsQueryable();
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            if (id == null) return null;
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int? categoryId)
        {
            if (!categoryId.HasValue)
            {
                return await _entities.ToListAsync();
            }

            return await _entities
                .Where(p => p.CategoryId == categoryId) 
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithCategories()
        {
            var products = await _entities
                .Where(m => m.SoftDelete == false)
                .Include(m => m.Category)
                .ToListAsync();
            return products;
        }



        public async Task UpdateAsync(Product entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SortProductsAsync(string sortOrder)
        {
            var query = _entities.Where(m => m.SoftDelete == false).AsQueryable();

            switch (sortOrder?.ToLower())
            {
                case "low-to-high":
                    query = query.OrderBy(p => p.Price);
                    break;

                case "high-to-low":
                    query = query.OrderByDescending(p => p.Price);
                    break;

                default:
                    throw new ArgumentException($"Неизвестный параметр сортировки: {sortOrder}", nameof(sortOrder));
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _entities
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
        }


    }
}

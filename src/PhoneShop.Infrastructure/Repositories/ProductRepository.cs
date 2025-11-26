using PhoneShop.Application.Interfaces;
using PhoneShop.Domain.Entities;
using PhoneShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.Products.FindAsync(id);
            if (entity != null)
            {
                _db.Products.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _db.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(Guid id) => await _db.Products.FindAsync(id);

        public async Task UpdateAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}

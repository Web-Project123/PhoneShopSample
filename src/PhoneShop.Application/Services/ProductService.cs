using PhoneShop.Application.Interfaces;
using PhoneShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneShop.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public Task<IEnumerable<Product>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Product> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);

        public async Task AddAsync(string name, decimal price, int stock)
        {
            var p = new Product(name, price, stock);
            await _repo.AddAsync(p);
        }

        public async Task DecreaseStock(Guid productId, int amount)
        {
            var p = await _repo.GetByIdAsync(productId);
            if (p == null) throw new Exception("Product not found");
            p.DecreaseStock(amount);
            await _repo.UpdateAsync(p);
        }
    }
}

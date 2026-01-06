using Web_Project.Domain.Entities;
using Web_Project.Domain.Interfaces;

namespace Web_Project.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>()
    {
    new Product
    {
        Id = 1,
        Name = "iPhone 15 Pro",
        Category = "Mobile",
        Brand = "Apple",
        Price = 85000000,
        Stock = 5,
        Description = "Apple flagship phone"
    },
    new Product
    {
        Id = 2,
        Name = "Galaxy Tab S9",
        Category = "Tablet",
        Brand = "Samsung",
        Price = 45000000,
        Stock = 3,
        Description = "High-end Android tablet"
    },
    new Product
    {
        Id = 3,
        Name = "MacBook Pro 16",
        Category = "Laptop",
        Brand = "Apple",
        Price = 200000000,
        Stock = 2,
        Description = "Powerful laptop for professionals"
    },
    new Product
    {
        Id = 4,
        Name = "Logitech MX Master 3",
        Category = "Accessory",
        Brand = "Logitech",
        Price = 3500000,
        Stock = 10,
        Description = "Premium wireless mouse"
    }
};


        public List<Product> GetAll() => products;

        public Product? GetById(int id) => products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product) => products.Add(product);
    }
}

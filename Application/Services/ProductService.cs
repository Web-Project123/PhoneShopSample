using Web_Project.Domain.Entities;
using Web_Project.Domain.Interfaces;

namespace Web_Project.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public List<Product> GetAllProducts() => _repo.GetAll();

        public Product? GetProduct(int id) => _repo.GetById(id);

        public void AddProduct(Product product) => _repo.Add(product);
    }
}

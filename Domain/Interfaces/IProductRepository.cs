using Web_Project.Domain.Entities;

namespace Web_Project.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
    }
}

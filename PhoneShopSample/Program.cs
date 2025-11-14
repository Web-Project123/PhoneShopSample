using PhoneShopSample.Models;
using PhoneShopSample.Models;

var products = new List<Product>
{
    new Product { Id = 1, Name = "Iphone", Price = 300, Stock = 5 },
    new Product { Id = 2, Name = "Samsong",  Price = 200,   Stock = 20 },
    new Product { Id = 3, Name = "Xiaomi", Price = 100, Stock = 50 },
    new Product { Id = 4, Name = "Huawei", Price = 50, Stock = 2 }
};



Console.WriteLine("Products List:");
foreach (var p in products)
{
    Console.WriteLine($"{p.Id}: {p.Name} - {p.Price} - Stock: {p.Stock}");
}
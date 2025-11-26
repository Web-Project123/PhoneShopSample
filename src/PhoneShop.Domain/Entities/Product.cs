using System;

namespace PhoneShop.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        // ctor برای ساخت امن موجودیت
        public Product(string name, decimal price, int stock)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Stock = stock;
        }

        public void DecreaseStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be > 0");
            if (amount > Stock) throw new InvalidOperationException("Insufficient stock");
            Stock -= amount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be > 0");
            Stock += amount;
        }
    }
}

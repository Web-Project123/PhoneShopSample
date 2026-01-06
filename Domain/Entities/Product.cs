namespace Web_Project.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; } // Mobile, Tablet, Laptop, Accessory

        public decimal Price { get; set; }

        public string Brand { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }
    }
}

namespace Katas.SupermarketKata
{
    public class Product : IProduct
    {
        public Product()
        {
            
        }

        public Product(string description, decimal price)
        {
            Description = description;
            Price = price;
        }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
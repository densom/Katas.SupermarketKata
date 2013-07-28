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

        public Product(string description, decimal price, string weightUnit):this(description, price)
        {
           WeightUnit = weightUnit;
            IsByWeight = true;
        }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsByWeight { get; private set; }
        public string WeightUnit { get; set; }
    }
}
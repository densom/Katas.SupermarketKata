namespace Katas.SupermarketKata
{
    public class Product : IProduct
    {
        private readonly decimal _price;

        public Product(string description, decimal price)
        {
            Description = description;
            _price = price;
        }

        public decimal Price
        {
            get { return _price; }
        }

        public string Description { get; private set; }
    }
}
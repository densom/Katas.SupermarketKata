namespace Katas.SupermarketKata
{
    public class CartItem
    {
        public CartItem(IProduct product, int quantity)
        {
            Quantity = quantity;
            Product = product;
        }

        public int Quantity { get; set; }
        public IProduct Product { get; private set; }

        public decimal ExtendedPrice
        {
            get { return Quantity * ItemPrice; }
            
        }

        public decimal ItemPrice
        {
            get { return Product.Price; }
        }
    }
}
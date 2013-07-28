using Katas.SupermarketKata;

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
        private IProduct Product { get; set; }

        public decimal Price
        {
            get { return Product.Price; }
        }

        public string Description
        {
            get { return Product.Description; }
        }

        public string PriceString
        {
            get
            {
                return FormatPriceString();
            }
        }

        private string FormatPriceString()
        {
            if (Product.IsByWeight)
            {
                return string.Format(@"{0:c}\{1}", Product.Price, Product.WeightUnit);
            }

            return string.Format("{0:c}", Product.Price);
        }

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
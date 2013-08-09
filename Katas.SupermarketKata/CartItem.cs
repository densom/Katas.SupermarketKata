namespace Katas.SupermarketKata
{
    public abstract class CartItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; protected set; }
        public string Description { get; protected set; }

        public string PriceString
        {
            get
            {
                return FormatPriceString();
            }
        }

        public decimal ExtendedPrice { get { return Quantity * Price; } }
        public virtual string FormatPriceString()
        {
            return string.Format("{0:c}", Price);
        }

    }
}
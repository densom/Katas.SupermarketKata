namespace Katas.SupermarketKata
{
    public class DiscountCartItem : CartItem
    {
        public DiscountCartItem(string description, decimal price, int quantity)
        {
            Price = price;
            Description = description;
            Quantity = quantity;
        }
    }
}
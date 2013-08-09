using System.Linq;

namespace Katas.SupermarketKata
{
    public class BuyXForYPromotion : Promotion
    {
        public IProduct Product { get; private set; }
        public int BuyX { get; private set; }
        public decimal ForPriceY { get; set; }

        public BuyXForYPromotion(Cart cart, IProduct product, int buyX, decimal forPriceY) : base(cart)
        {
            Product = product;
            BuyX = buyX;
            ForPriceY = forPriceY;
        }

        internal override bool IsApplicable()
        {
            int quantityInCart = QuantityOfPromoItemsInCart();
            return quantityInCart >= BuyX;
        }

        internal int QuantityOfPromoItemsInCart()
        {
            return PromotionItemInCart().Quantity;
        }

        private CartItem PromotionItemInCart()
        {
            return Cart.Items.First(item => item.Description == Product.Description);
        }

        public override void Apply()
        {
            if (!IsApplicable())
                return;

            Cart.Add(new DiscountCartItem(DiscountItemDescription(), DiscountItemPrice(), 1));

        }

        private decimal DiscountItemPrice()
        {
            return (PromotionItemInCart().ExtendedPrice - CalculatedDiscountPrice()) * -1;
        }

        private string DiscountItemDescription()
        {
            return string.Format("Buy {0} for {1:C}: {2}", BuyX, ForPriceY, Product.Description);
        }


        public int DiscountItemsEarned()
        {
            return QuantityOfPromoItemsInCart()/BuyX;
        }

        public decimal CalculatedDiscountPrice()
        {
            return ForPriceY * DiscountItemsEarned();
        }
    }
}
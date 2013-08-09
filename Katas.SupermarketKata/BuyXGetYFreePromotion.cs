using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.SupermarketKata
{
    
    public class BuyXGetYFreePromotion : Promotion
    {
        public IProduct Product { get; private set; }
        public int BuyX { get; private set; }
        public int GetY { get; private set; }

        public BuyXGetYFreePromotion(Cart cart, IProduct product, int buyX, int getY):base(cart)
        {
            Product = product;
            BuyX = buyX;
            GetY = getY;

        }

        public override void Apply()
        {
            if (!IsApplicable())
            {
                return;
            }

            for (int i = 0; i < DiscountItemsEarned(); i++)
            {
                Cart.Add(new DiscountCartItem(string.Format("Buy {0} get {1}: {2}",BuyX, GetY, Product.Description), CalculatedDiscountPrice(), 1));
            }
        }

        internal decimal CalculatedDiscountPrice()
        {
            return Product.Price * GetY * -1;
        }

        internal int DiscountItemsEarned()
        {
            return QuantityOfPromoItemsInCart()/BuyX;
        }

        internal int QuantityOfPromoItemsInCart()
        {
            return WhereIsPromoItem().Sum(item => item.Quantity);
        }

        private IEnumerable<CartItem> WhereIsPromoItem()
        {
            return Cart.Items.Where(item => item.Description == Product.Description);
        }

        internal override bool IsApplicable()
        {
            if (Cart[Product.Description].Quantity >= BuyX)
            {
                return true;
            }

            return false;
        }
    }
}
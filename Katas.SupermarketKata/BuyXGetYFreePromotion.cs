using System;
using System.Linq;

namespace Katas.SupermarketKata
{
    public class BuyXGetYFreePromotion
    {
        public IProduct Product { get; private set; }
        public int BuyX { get; private set; }
        public int GetY { get; private set; }
        public Cart Cart { get; private set; }

        public BuyXGetYFreePromotion(Cart cart, IProduct product, int buyX, int getY)
        {
            Cart = cart;
            Product = product;
            BuyX = buyX;
            GetY = getY;

        }

        public void Apply()
        {
            if (!IsApplicable())
            {
                return;
            }

        }

        internal bool IsApplicable()
        {
            if (Cart[Product.Description].Quantity >= BuyX)
            {
                return true;
            }

            return false;
        }
    }
}
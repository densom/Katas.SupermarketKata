using System;

namespace Katas.SupermarketKata
{
    public class BuyXGetYFreePromotion
    {
        public IProduct Product { get; private set; }
        public int BuyX { get; private set; }
        public int GetY { get; private set; }

        public BuyXGetYFreePromotion(IProduct product, int buyX, int getY)
        {
            Product = product;
            BuyX = buyX;
            GetY = getY;

        }

        public void Apply(Cart cart)
        {
            if (!IsApplicable())
            {
                return;
            }

        }

        internal bool IsApplicable()
        {
            return false;
        }
    }
}
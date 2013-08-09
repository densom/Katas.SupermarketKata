namespace Katas.SupermarketKata
{
    public abstract class Promotion
    {
        public Cart Cart { get; private set; }

        protected Promotion(Cart cart)
        {
            Cart = cart;
        }

        internal abstract bool IsApplicable();
        public abstract void Apply();
    }
}
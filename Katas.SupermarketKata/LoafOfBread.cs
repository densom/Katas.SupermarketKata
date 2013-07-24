namespace Katas.SupermarketKata
{
    public class LoafOfBread : IProduct
    {
        private const decimal LoafOfBreadPrice = 1m;

        public decimal Price
        {
            get { return LoafOfBreadPrice; }
        }

        public string Description { get { return "Loaf of Bread"; } }
    }
}
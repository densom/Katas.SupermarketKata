namespace Katas.SupermarketKata
{
    public class ProductByWeight : Product, IWeighableProduct
    {

        public ProductByWeight(string description, decimal price, string unitOfWeight) : base(description, price)
        {
            UnitOfWeight = unitOfWeight;
        }

        public string UnitOfWeight { get; set; }
        
    }
}
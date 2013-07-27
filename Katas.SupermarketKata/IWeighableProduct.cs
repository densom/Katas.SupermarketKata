namespace Katas.SupermarketKata
{
    public interface IWeighableProduct : IProduct
    {
        string UnitOfWeight { get; }
    }
}
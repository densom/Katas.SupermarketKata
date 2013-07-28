namespace Katas.SupermarketKata
{
    public interface IProduct
    {
        decimal Price { get; }
        string Description { get; }
        bool IsByWeight { get; }
        string WeightUnit { get; set; }
    }
}
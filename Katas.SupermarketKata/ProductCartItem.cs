using Katas.SupermarketKata;

namespace Katas.SupermarketKata
{
    public class ProductCartItem : CartItem
    {
        public ProductCartItem(IProduct product, int quantity)
        {
            Quantity = quantity;
            Product = product;
            Price = product.Price;
            Description = product.Description;
        }

        private IProduct Product { get; set; }


        public override string FormatPriceString()
        {
            if (Product.IsByWeight)
            {
                return string.Format(@"{0:c}\{1}", Price, Product.WeightUnit);
            }

            return base.FormatPriceString();
        }

    }
}
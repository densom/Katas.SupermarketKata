using System.Text;

namespace Katas.SupermarketKata
{
    public class CartDisplayer
    {
        private Cart _cart;

        public CartDisplayer(Cart cart)
        {
            _cart = cart;
        }


        public string this[int i]
        {
            get { return ShowProduct(i); }
        }

        private string ShowProduct(int i)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Product: {0}\t", _cart[i].Product.Description);
            sb.AppendFormat("Price: {0}\t", GetPriceString(_cart[i].Product));
            sb.AppendFormat("Extended Price: {0:c}", _cart[i].ExtendedPrice);

            return sb.ToString();
        }

        private string GetPriceString(IProduct product)
        {
            if (product is IWeighableProduct)
            {
                // IWeighableProduct will not work.  It is too specific and does not belong to IProduct
                // Need to figure out best place to handle formatting the price string.
                return string.Format("{0:c}/{1}", product.Price, product.Weight);
            }

            return string.Format("{0:c}", product.Price);
        }


        public string Total()
        {
            return string.Format("Total: {0:c}", _cart.Total());
        }
    }
}
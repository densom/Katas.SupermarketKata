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
            return string.Format("{0:c}", product.Price);
        }


        public string Total()
        {
            return string.Format("Total: {0:c}", _cart.Total());
        }
    }
}
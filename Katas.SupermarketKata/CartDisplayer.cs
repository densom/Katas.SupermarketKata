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
            sb.AppendFormat("Product: {0}\t", _cart[i].Description);
            sb.AppendFormat("Price: {0}\t", _cart[i].PriceString);
            sb.AppendFormat("Extended Price: {0:c}", _cart[i].ExtendedPrice);

            return sb.ToString();
        }

        public string Total()
        {
            return string.Format("Total: {0:c}", _cart.Total());
        }
    }
}
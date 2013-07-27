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
            return string.Format("Product: {0}\tPrice: {1:c}\tExtended Price: {2:c}", _cart[i].Product.Description, _cart[i].Product.Price, _cart[i].ExtendedPrice);
        }
    }
}
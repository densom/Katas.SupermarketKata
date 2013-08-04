using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.SupermarketKata
{
    public class Cart
    {
        readonly Dictionary<string, CartItem> _cartItems = new Dictionary<string, CartItem>();

        public IEnumerable<CartItem> Items
        {
            get { return _cartItems.Values.ToList().AsReadOnly(); }
        }

        public decimal Total()
        {
            return _cartItems.Sum(item => item.Value.Price * item.Value.Quantity);
        }

        public void Add(IProduct product)
        {
            var item = new CartItem(product, 1);
            _cartItems.Add(product.Description, item);
        }

        public void Add(CartItem item)
        {
            if (ProductAlreadyInCart(item))
            {
                IncreaseQuantity(item);
                return;
            }

            _cartItems.Add(item.Description,item);
        }

        private void IncreaseQuantity(CartItem item)
        {
            _cartItems[item.Description].Quantity += item.Quantity;
        }

        private bool ProductAlreadyInCart(CartItem item)
        {
            return _cartItems.ContainsKey(item.Description);
        }

        public CartItem this[int i]
        {
            get { return _cartItems.Values.ToList()[i]; }
        }

        public CartItem this[string productDescription]
        {
            get { return _cartItems[productDescription]; }
        }

        public void Add(IProduct product, int quantity)
        {
            Add(new CartItem(product, quantity));
        }

        public void AddRange(IEnumerable<IProduct> products)
        {
            products.ToList().ForEach(Add);
        }

        public void ApplyPromotion(BuyXGetYFreePromotion promotion)
        {
            promotion.Apply();
        }
    }
}

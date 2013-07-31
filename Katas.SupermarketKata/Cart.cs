using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.SupermarketKata
{
    public class Cart
    {
        readonly List<CartItem> _cartItems = new List<CartItem>();

        public decimal Total()
        {
            return _cartItems.Sum(item => item.Product.Price * item.Quantity);
        }

        public void Add(IProduct product)
        {
            var item = new CartItem(product, 1);
            _cartItems.Add(item);
        }

        public void Add(CartItem item)
        {
            _cartItems.Add(item);
        }

        public CartItem this[int i]
        {
            get { return _cartItems[i]; }
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
            promotion.Apply(this);
        }
    }
}

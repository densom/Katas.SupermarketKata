using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.SupermarketKata
{
    public class Cart
    {
        readonly Dictionary<string, ProductCartItem> _cartItems = new Dictionary<string, ProductCartItem>();

        public IEnumerable<ProductCartItem> Items
        {
            get { return _cartItems.Values.ToList().AsReadOnly(); }
        }

        public decimal Total()
        {
            return _cartItems.Sum(item => item.Value.Price * item.Value.Quantity);
        }

        public void Add(IProduct product)
        {
            var item = new ProductCartItem(product, 1);
            _cartItems.Add(product.Description, item);
        }

        public void Add(ProductCartItem item)
        {
            if (ProductAlreadyInCart(item))
            {
                IncreaseQuantity(item);
                return;
            }

            _cartItems.Add(item.Description,item);
        }

        private void IncreaseQuantity(ProductCartItem item)
        {
            _cartItems[item.Description].Quantity += item.Quantity;
        }

        private bool ProductAlreadyInCart(ProductCartItem item)
        {
            return _cartItems.ContainsKey(item.Description);
        }

        public ProductCartItem this[int i]
        {
            get { return _cartItems.Values.ToList()[i]; }
        }

        public ProductCartItem this[string productDescription]
        {
            get { return _cartItems[productDescription]; }
        }

        public void Add(IProduct product, int quantity)
        {
            Add(new ProductCartItem(product, quantity));
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

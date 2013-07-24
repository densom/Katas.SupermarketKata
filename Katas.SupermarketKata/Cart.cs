using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.SupermarketKata
{
    public class Cart
    {
        List<CartItem> _cartItems = new List<CartItem>(); 

        public decimal Total()
        {
            return _cartItems.Sum(item => item.Product.Price * item.Quantity);
        }

        public void Add(IProduct product)
        {
            var item = new CartItem(product, 1);
            _cartItems.Add(item);
        }
    }

    public class CartItem
    {
        public CartItem(IProduct product, int quantity)
        {
            Quantity = quantity;
            Product = product;
        }

        public int Quantity { get; set; }
        public IProduct Product { get; private set; }
    }

    public class LoafOfBread : IProduct
    {
        private const decimal LoafOfBreadPrice = 1m;

        public decimal Price
        {
            get { return LoafOfBreadPrice; }
        }
    }

    public interface IProduct
    {
        decimal Price { get; }
    }
}

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
    }

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

    public class CartItem
    {
        public CartItem(IProduct product, int quantity)
        {
            Quantity = quantity;
            Product = product;
        }

        public int Quantity { get; set; }
        public IProduct Product { get; private set; }

        public decimal ExtendedPrice
        {
            get { return Quantity * ItemPrice; }
            
        }

        public decimal ItemPrice
        {
            get { return Product.Price; }
        }
    }

    public class LoafOfBread : IProduct
    {
        private const decimal LoafOfBreadPrice = 1m;

        public decimal Price
        {
            get { return LoafOfBreadPrice; }
        }

        public string Description { get { return "Loaf of Bread"; } }
    }

    public interface IProduct
    {
        decimal Price { get; }
        string Description { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Katas.SupermarketKata.Tests
{
    [TestFixture]
    public class CartTests
    {
        private const decimal LoafOfBreadPrice = 1m;

        [Test]
        public void GetTotal_EmptyCartReturnsZero()
        {
            var cart = new Cart();
            Assert.That(cart.Total(), Is.EqualTo(0));
        }



        [Test]
        public void GetTotal_AddProduct_NoQuantitySpecified()
        {
            var cart = new Cart();
            cart.Add(new LoafOfBread());
            Assert.That(cart.Total(), Is.EqualTo(LoafOfBreadPrice));
        }

        [Test]
        public void GetTotal_AddProduct_MoreThanOneQuantity()
        {
            var cart = new Cart();
            cart.Add(new LoafOfBread(), 2);
            Assert.That(cart.Total(), Is.EqualTo(LoafOfBreadPrice * 2));
        }



    }

    [TestFixture]
    public class CartDisplayerTests
    {
        [Test]
        public void CartDisplayer_DisplaySingleItem()
        {
            var cart = new Cart();
            cart.Add(new LoafOfBread(), 2);
            CartDisplayer displayer = new CartDisplayer(cart);
            Assert.That(displayer[0], Is.EqualTo("Product: Loaf of Bread\tPrice: $1.00\tExtended Price: $2.00"));

        }
    }

    [TestFixture]
    public class CartItemTests
    {
        [Test]
        public void CreateCartItem()
        {
            var loafOfBread = new LoafOfBread();
            var item = new CartItem(loafOfBread, 1);
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.AreSame(item.Product, loafOfBread);
        }
    }

    [TestFixture]
    public class ProductTests
    {
        private const decimal PriceLoadOfBread = 1m;

        [Test]
        public void CreateProduct()
        {
            var bread = new LoafOfBread();
            Assert.That(bread.Price, Is.EqualTo(PriceLoadOfBread));
        }
    }


}

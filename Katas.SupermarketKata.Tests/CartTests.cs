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
        public void GetTotal_LoafOfBread()
        {
            var cart = new Cart();
            cart.Add(new LoafOfBread());
            Assert.That(cart.Total(), Is.EqualTo(LoafOfBreadPrice));
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

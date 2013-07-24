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
}

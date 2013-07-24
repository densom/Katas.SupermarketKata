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
            cart.Add(Products.LoafOfBread);
            Assert.That(cart.Total(), Is.EqualTo(LoafOfBreadPrice));
        }

        [Test]
        public void GetTotal_AddProduct_MoreThanOneQuantity()
        {
            var cart = new Cart();
            cart.Add(Products.LoafOfBread, 2);
            Assert.That(cart.Total(), Is.EqualTo(LoafOfBreadPrice * 2));
        }

        [Test]
        public void GetTotal_AllProducts()
        {
            var cart = new Cart();
            cart.AddRange(new[] {Products.LoafOfBread, Products.Noodles, Products.SoupCans});
            Assert.That(cart.Total(), Is.EqualTo(3.5m));
        }
    }
}

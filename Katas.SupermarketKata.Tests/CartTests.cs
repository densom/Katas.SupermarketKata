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

        [Test]
        public void GetTotal_ByWeightProduct()
        {
            var cart = new Cart();
            cart.Add(Products.Apples, 1);
            Assert.That(cart.Total(), Is.EqualTo(2));
        }

        [Test]
        public void Promotion_BuyXGetYFree_IsApplicable_False()
        {
            var cart = new Cart();
            cart.Add(Products.SoupCans, 4);
            var promotion = new BuyXGetYFreePromotion(Products.SoupCans, 3, 1);
            Assert.That(promotion.IsApplicable(), Is.False);
        }

        [Test]
        public void Promotion_BuyXGetYFree_IsApplicable_True()
        {
            var cart = new Cart();
            cart.Add(Products.SoupCans, 4);
            var promotion = new BuyXGetYFreePromotion(Products.SoupCans, 4, 1);
            Assert.That(promotion.IsApplicable(), Is.True);
        }

        [Test]
        [Ignore]
        public void Promotion_BuyXGetYFree()
        {
            var cart = new Cart();
            cart.Add(Products.SoupCans, 4);
            cart.ApplyPromotion(new BuyXGetYFreePromotion(Products.SoupCans, 4, 1));
            Assert.That(cart.Total(), Is.EqualTo(Products.SoupCans.Price * 3));
        }
    }
}

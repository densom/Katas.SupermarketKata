using NUnit.Framework;

namespace Katas.SupermarketKata.Tests
{
    [TestFixture]
    public class BuyXGetYFreeTests
    {
        [Test]
        public void IsApplicable_False()
        {
            var cart = new Cart();
            cart.Add(Products.SoupCans, 3);
            var promotion = new BuyXGetYFreePromotion(cart, Products.SoupCans, 4, 1);
            Assert.That(promotion.IsApplicable(), Is.False);
        }

        [Test]
        public void IsApplicable_True()
        {
            var cart = new Cart();
            cart.Add(Products.SoupCans, 4);
            var promotion = new BuyXGetYFreePromotion(cart, Products.SoupCans, 4, 1);
            Assert.That(promotion.IsApplicable(), Is.True);
        }

        [Test]
        public void QuantityOfPromoItemsInCart_FindsAccurateSum()
        {
            //setup
            var cart = new Cart();
            cart.Add(Products.SoupCans, 4);
            var promotion = new BuyXGetYFreePromotion(cart, Products.SoupCans, 4, 1);
            
            //test
            cart.ApplyPromotion(promotion);
            
            //verification
            Assert.That(promotion.QuantityOfPromoItemsInCart(), Is.EqualTo(4));
        }

        [Test]
        public void ApplyPromotion_DiscountsSingleLineItem()
        {
            var cart = new Cart();
            cart.Add(Products.SoupCans, 4);
            cart.ApplyPromotion(new BuyXGetYFreePromotion(cart, Products.SoupCans, 4, 1));
            Assert.That(cart.Total(), Is.EqualTo(Products.SoupCans.Price * 3));
        }
    }
}
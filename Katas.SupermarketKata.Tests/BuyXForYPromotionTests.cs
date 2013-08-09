using NUnit.Framework;
using System.Linq;

namespace Katas.SupermarketKata.Tests
{
    [TestFixture]
    public class BuyXForYPromotionTests
    {

        [Test]
        public void IsApplicable_False()
        {
            var cart = new Cart();
            cart.Add(Products.SoupCans, 2);
            var promotion = new BuyXForYPromotion(cart, Products.SoupCans, 3, 1);
            Assert.That(promotion.IsApplicable(), Is.False);
        }

        [Test]
        public void IsApplicable_True()
        {
            var cart = new Cart();
            cart.Add(Products.SoupCans, 3);
            var promotion = new BuyXForYPromotion(cart, Products.SoupCans, 3, 1); 
            Assert.That(promotion.IsApplicable(), Is.True);
        }

        [Test]
        public void QuantityOfPromoItemsInCart_FindsAccurateSum()
        {
            //setup
            var cart = new Cart();
            cart.Add(Products.SoupCans, 3);
            var promotion = new BuyXForYPromotion(cart, Products.SoupCans, 3, 1); 
            
            //test
            cart.ApplyPromotion(promotion);
            
            //verification
            Assert.That(promotion.QuantityOfPromoItemsInCart(), Is.EqualTo(3));
            Assert.That(promotion.DiscountItemsEarned(), Is.EqualTo(1));
        }

        [Test]
        public void ApplyPromotion_CalculatedDiscountPriceForSinglePromotionCriteria()
        {
            decimal promotionPrice = 1.00m;
            int quantityToBuyForEligibility = 3;

            var cart = new Cart();
            cart.Add(Products.SoupCans, quantityToBuyForEligibility);


            
            var promotion = new BuyXForYPromotion(cart, Products.SoupCans, quantityToBuyForEligibility, promotionPrice);
            cart.ApplyPromotion(promotion);

            Assert.That(promotion.CalculatedDiscountPrice(), Is.EqualTo(promotionPrice));
        }

        [Test]
        public void ApplyPromotion_DiscountsSingleLineItem()
        {
            decimal promotionPrice = 1.00m;
            int quantityToBuyForEligibility = 3;

            var cart = new Cart();
            cart.Add(Products.SoupCans, quantityToBuyForEligibility);
            cart.ApplyPromotion(new BuyXForYPromotion(cart, Products.SoupCans,quantityToBuyForEligibility, promotionPrice));
            Assert.That(cart.Total(), Is.EqualTo(promotionPrice));
            Assert.That(cart.Items.Count(item => item.Description == "Buy 3 for $1.00: Soup Cans"), Is.EqualTo(1));
        }

        [Test]
        public void ApplyPromotion_DiscountsMultipleLineItem()
        {
            decimal promotionPrice = 1.00m;
            int quantityToBuyForEligibility = 3;

            var cart = new Cart();
            cart.Add(Products.SoupCans, quantityToBuyForEligibility * 2);
            cart.ApplyPromotion(new BuyXForYPromotion(cart, Products.SoupCans, quantityToBuyForEligibility, promotionPrice));
            Assert.That(cart.Total(), Is.EqualTo(promotionPrice * 2));
            Assert.That(cart.Items.Count(item => item.Description == "Buy 3 for $1.00: Soup Cans"), Is.EqualTo(1));
        }
    }
}
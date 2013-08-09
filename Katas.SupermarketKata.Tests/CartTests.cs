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
        public void AddProduct_WhenProductAlreadyExists_IncreaseQuantity()
        {
            var cart = new Cart();
            cart.Add(Products.LoafOfBread, 1);

            Assert.That(cart[0].Description, Is.EqualTo(Products.LoafOfBread.Description));
            Assert.That(cart[0].Quantity, Is.EqualTo(1));

            cart.Add(Products.LoafOfBread, 1);

            Assert.That(cart[0].Description, Is.EqualTo(Products.LoafOfBread.Description));
            Assert.That(cart[0].Quantity, Is.EqualTo(2));
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

//        [Test]
//        public void RemovePromotions_Success()
//        {
//            var cart = new Cart();
//            cart.Add(Products.SoupCans, 4);
//            cart.ApplyPromotion();
//        }

 

        
    }
}

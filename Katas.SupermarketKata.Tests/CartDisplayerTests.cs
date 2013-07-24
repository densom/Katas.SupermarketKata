using NUnit.Framework;

namespace Katas.SupermarketKata.Tests
{
    [TestFixture]
    public class CartDisplayerTests
    {
        [Test]
        public void CartDisplayer_DisplaySingleItem()
        {
            var cart = new Cart();
            cart.Add(Products.LoafOfBread, 2);
            var displayer = new CartDisplayer(cart);
            Assert.That(displayer[0], Is.EqualTo("Product: Loaf of Bread\tPrice: $1.00\tExtended Price: $2.00"));
        }
    }
}
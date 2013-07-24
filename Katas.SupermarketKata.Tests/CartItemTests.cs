using NUnit.Framework;

namespace Katas.SupermarketKata.Tests
{
    [TestFixture]
    public class CartItemTests
    {
        [Test]
        public void CreateCartItem()
        {
            var item = new CartItem(Products.LoafOfBread, 1);
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.AreSame(item.Product, Products.LoafOfBread);
        }
    }
}
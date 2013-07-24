using NUnit.Framework;

namespace Katas.SupermarketKata.Tests
{
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
}
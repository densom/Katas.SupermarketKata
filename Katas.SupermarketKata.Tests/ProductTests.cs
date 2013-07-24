using NUnit.Framework;

namespace Katas.SupermarketKata.Tests
{
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
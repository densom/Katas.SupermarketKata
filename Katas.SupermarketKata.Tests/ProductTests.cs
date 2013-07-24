using NUnit.Framework;

namespace Katas.SupermarketKata.Tests
{
    [TestFixture]
    public class ProductTests
    {
        private const decimal PriceLoadOfBread = 1m;
        private Product _loafOfBread = new Product("Loaf of Bread", PriceLoadOfBread);

        [Test]
        public void CreateProduct()
        {
            Assert.That(_loafOfBread.Price, Is.EqualTo(PriceLoadOfBread));
        }
    }
}
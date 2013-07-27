using NUnit.Framework;

namespace Katas.SupermarketKata.Tests
{
    [TestFixture]
    public class CartDisplayerTests
    {
        [Test]
        public void Iterator_DisplaySingleItem()
        {
            var cart = new Cart();
            cart.Add(Products.LoafOfBread, 2);
            var displayer = new CartDisplayer(cart);
            Assert.That(displayer[0], Is.EqualTo("Product: Loaf of Bread\tPrice: $1.00\tExtended Price: $2.00"));
        }

        [Test]
        public void Iterator_DisplayAllItems()
        {
            var cart = new Cart();
            cart.AddRange(Products.AllBasicProducts);
            var displayer = new CartDisplayer(cart);
            Assert.That(displayer[0], Is.EqualTo("Product: Loaf of Bread\tPrice: $1.00\tExtended Price: $1.00"));
            Assert.That(displayer[1], Is.EqualTo("Product: Noodles\tPrice: $0.50\tExtended Price: $0.50"));
            Assert.That(displayer[2], Is.EqualTo("Product: Soup Cans\tPrice: $2.00\tExtended Price: $2.00"));
        }

        [Test]
        public void TotalCost()
        {
            var cart = new Cart();
            cart.AddRange(Products.AllBasicProducts);
            var displayer = new CartDisplayer(cart);
            Assert.That(displayer.Total(), Is.EqualTo("Total: $3.50"));
        }

        [Test]
        public void Iterator_DisplayProductByWeight()
        {
            var cart = new Cart();
            cart.Add(Products.Apples);
            var displayer = new CartDisplayer(cart);
            Assert.That(displayer[0], Is.EqualTo("Product: Apples\tPrice: $2.00\\lb.\tExtended Price: $2.00"));
        }
    }
}
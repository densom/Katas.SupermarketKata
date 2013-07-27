using System.Collections.Generic;

namespace Katas.SupermarketKata.Tests
{
    public static class Products
    {
        public static readonly IProduct LoafOfBread = new Product("Loaf of Bread", 1m);
        public static readonly IProduct Noodles = new Product("Noodles", .5m);
        public static readonly IProduct SoupCans = new Product("Soup Cans", 2m);

        public static readonly IEnumerable<IProduct> AllBasicProducts = new[] {LoafOfBread, Noodles, SoupCans};

        public static readonly IWeighableProduct Apples = new ProductByWeight("Apples", 2, "lb.");
    }

    
}
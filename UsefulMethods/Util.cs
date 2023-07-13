using Bogus;
using CompraService.Database;
using CompraService.Models;

namespace CompraService.UsefulMethods
{
    public static class Util
    {
        public static void PopulateDatabase(DatabaseContext databaseContext)
        {
            var productFaker = new Faker<Product>()
                .RuleFor(x => x.Client_Id, y => y.Random.Int(9999))
                .RuleFor(x => x.Product_Id, y => y.Random.Int(9999))
                .RuleFor(x => x.Product_Name, y => y.Commerce.Product())
                .RuleFor(x => x.Product_Price, y => y.Random.Double(9999))
                .RuleFor(x => x.Amount, y => y.Random.Int(50));

            var products = productFaker.Generate(10);

            databaseContext.Product.AddRange(products);
            databaseContext.SaveChanges();
        }
    }
}

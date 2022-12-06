using ProductGrpc.Models;

namespace ProductGrpc.Data
{
    public class NorthwindDbContextSeed
    {
        public static void  SeedAsync(NorthwindDbContext northwindDbContext) 
        {
            if (!northwindDbContext.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { ProductId = 1,ProductName = "Onur", QuantityPerUnit ="10"}
                };

                northwindDbContext.Products.AddRange(products);
                northwindDbContext.SaveChanges();
            }
        }
    }
}

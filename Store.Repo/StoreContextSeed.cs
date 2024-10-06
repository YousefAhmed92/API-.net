using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Entities;
using System.Text.Json;

namespace Store.Repo
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context , ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.productBrands != null && !context.productBrands.Any())
                {
                    var data = File.ReadAllText("../Store.Repo/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(data);

                    if (brands is not null)
                    {
                        await context.productBrands.AddRangeAsync(brands);
                    }
                }


                if (context.productTypes != null && !context.productTypes.Any())
                {
                    var data02 = File.ReadAllText("../Store.Repo/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(data02);

                    if (types is not null)
                    {
                        await context.productTypes.AddRangeAsync(types);
                    }
                }

                if (context.products != null && !context.products.Any())
                {
                    var data03 = File.ReadAllText("../Store.Repo/SeedData/products.json");
                    var p = JsonSerializer.Deserialize<List<Product>>(data03);

                    if (p is not null)
                    {
                        await context.products.AddRangeAsync(p);
                    }
                }

                if (context.deliveryMethods != null && !context.deliveryMethods.Any())
                {
                    var deliveryMethodsdata = File.ReadAllText("../Store.Repo/SeedData/delivery.json");
                    var d = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodsdata);

                    if (d is not null)
                    {
                        await context.deliveryMethods.AddRangeAsync(d);
                    }
                }

                Console.WriteLine("Saving changes..##########################.");

                await context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
                Console.WriteLine($"error in {ex.Message}");


            }   
        }
    }
}

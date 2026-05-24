using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Text.Json;

namespace Persistence
{
    public class DataSeeding(StoreDbContext _context) : IDataSeeding
    {
        //private readonly StoreDbContext _context = context;

        public async Task DataSeedAsync()
        {
            try
            {
                var PendingMigrations =await _context.Database.GetPendingMigrationsAsync();
                if (PendingMigrations.Any())
                   await _context.Database.MigrateAsync();
                if (!_context.ProductBrands.Any())
                {
                    var BrandsData = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\brands.json");
                    var Brands =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(BrandsData);
                    if (Brands != null && Brands.Any())
                      await _context.ProductBrands.AddRangeAsync(Brands);
                }
                if (!_context.ProductTypes.Any())
                {
                    var ProductTypesData = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\types.json");
                    var ProductTypes =await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypesData);
                    if (ProductTypes != null && ProductTypes.Any())
                      await _context.ProductTypes.AddRangeAsync(ProductTypes);
                }
                if (!_context.Products.Any())
                {
                    var Data = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\products.json");
                    var products =await JsonSerializer.DeserializeAsync<List<Product>>(Data);
                    if (products != null && products.Any())
                      await  _context.Products.AddRangeAsync(products);
                }
               await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            
            }

        }
    }
}

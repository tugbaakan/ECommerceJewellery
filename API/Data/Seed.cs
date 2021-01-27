using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedProducts(DataContext context)
        {
            if (await context.Products.AnyAsync()) return;

            var productData = await System.IO.File.ReadAllTextAsync("Data/SeedProductData.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productData);
            if (products == null) return;

            foreach (var product in products )
            {
                await context.Products.AddAsync(product);
            }

            if (await context.Stocks.AnyAsync()) return;

            var stockData = await System.IO.File.ReadAllTextAsync("Data/SeedStockData.json");
            var stocks = JsonSerializer.Deserialize<List<Stock>>(stockData);
            if (stocks == null) return;

            foreach (var stock in stocks )
            {
                await context.Stocks.AddAsync(stock);
            }

            await context.SaveChangesAsync();


        }
    }
}
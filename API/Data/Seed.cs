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
        public static async Task SeedData(DataContext context)
        {
            await SeedCategories(context);
            await SeedProductTypes(context);
            await SeedUsers(context);
            await SeedSellers(context);
            await SeedProducts(context);
        
        }


        // Category
        public static async Task SeedCategories(DataContext context)
        {
            
            if (await context.Categories.AnyAsync()) return;
            var catData = await System.IO.File.ReadAllTextAsync("Data/SeedCategoryData.json");
            var cats = JsonSerializer.Deserialize<List<Category>>(catData);
            if (cats == null) return;
            foreach (var cat in cats )
            {
                await context.Categories.AddAsync(cat);
            }
            
            await context.SaveChangesAsync();
        }
        
        // ProductTypes
        public static async Task SeedProductTypes(DataContext context)
        {
            if (await context.ProductTypes.AnyAsync()) return;
            var productTypeData = await System.IO.File.ReadAllTextAsync("Data/SeedProductTypeData.json");
            var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
            if (productTypes == null) return;
            foreach (var productType in productTypes )
            {
                await context.ProductTypes.AddAsync(productType);
            }
            
            await context.SaveChangesAsync();
        }
            
        // Users
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;
            var userData = await System.IO.File.ReadAllTextAsync("Data/SeedUserData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;
            foreach (var user in users )
            {
                await context.Users.AddAsync(user);
            }
         
            await context.SaveChangesAsync();
        }

        // Sellers
        public static async Task SeedSellers(DataContext context)
        {
          
            if (await context.Sellers.AnyAsync()) return;
            var sellerData = await System.IO.File.ReadAllTextAsync("Data/SeedSellerData.json");
            var sellers = JsonSerializer.Deserialize<List<Seller>>(sellerData);
            if (sellers == null) return;
            foreach (var seller in sellers )
            {
                await context.Sellers.AddAsync(seller);
            }   
            
            await context.SaveChangesAsync();
        }

        // Products
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
            
            await context.SaveChangesAsync();
        }

    }
}
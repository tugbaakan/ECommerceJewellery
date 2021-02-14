

using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories {get; set;}
        public DbSet<ProductType> ProductTypes {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<AppUser> Users{ get; set; }
        public DbSet<Seller> Sellers {get; set;}
        public DbSet<Cart> Carts {get; set;}
        public DbSet<Carty> Carties {get; set;}

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);


        }*/
            

    }
}
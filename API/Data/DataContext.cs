

using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> Users{ get; set; }
        public DbSet<Product> Products {get; set;}
        public DbSet<Cart> Carts {get; set;}
        public DbSet<Carty> Carties {get; set;}
        public DbSet<Stock> Stocks {get; set;}

    }
}
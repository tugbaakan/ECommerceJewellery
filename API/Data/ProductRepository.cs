using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }
        
        public async Task<bool> ProductExist(int productId)
        {
            return await _context.Products.AnyAsync(x => x.Id == productId );
        }
        public async Task<bool> ProductExistStock(int productId)
        {
            var stock = await _context.Stocks.SingleOrDefaultAsync(x => x.ProductId == productId );
            if ( stock.StockQuantity > 0 )
                return true;
            return false;

        }
        public async Task<bool> ProductExistCart(int productId, int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if ( cart.Carties.Any(x => x.ProductId == productId ) )
            { 
                var carty = cart.Carties.Where( x => x.ProductId == productId).FirstOrDefault();
                if ( carty.Quantity > 0 )
                    return true;
                return false;
            }
            return false;

        }
        public void AddProduct(string productName, string productDescription= null)
        {
            var product = new Product{
                ProductName = productName,
                ProductDescription = productDescription
            };

            _context.Products.Add(product);
        
        }
        public void UpdateProduct(string productName, string productDescription=null)
        {
            var product = new Product{
                ProductName = productName,
                ProductDescription = productDescription
            };

            _context.Products.Update(product);

        }

        public async Task<bool> SaveAllAsync()
        {   
            return await _context.SaveChangesAsync() > 0;
        }

       
    }
}
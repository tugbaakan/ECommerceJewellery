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

       
    }
}
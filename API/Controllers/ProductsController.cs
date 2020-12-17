using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController: BaseAPIController
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // api/products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        [HttpPost()]
        public async Task<ActionResult<Product>> PostProduct(string productName )
        {
            var product = new Product{
                ProductName = productName
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

    }
}
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SellerController: BaseAPIController
    {
        private readonly DataContext _context;

        public SellerController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("addproduct")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
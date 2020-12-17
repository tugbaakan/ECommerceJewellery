using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SellerController: BaseAPIController
    {
        private readonly DataContext _context;

        public SellerController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("addproductstock")]
        public async Task<ActionResult<IEnumerable<Stock>>> AddProductStock(int productId, int stockQuantity)
        {
            // check if the product Id is correct
            if (! await ProductExist(productId)) return BadRequest("There is no such product");

            var product = await _context.Products.FindAsync(productId);

            if (await _context.Stocks.AnyAsync(x => x.ProductId == productId ))
            {
                var updatedStock = _context.Stocks.FirstOrDefault(x => x.ProductId == productId  );
                updatedStock.StockQuantity = updatedStock.StockQuantity + stockQuantity;
                _context.Stocks.Update(updatedStock);
            }
            else
            {  
                var stock = new Stock
                {
                    ProductId = productId,
                    StockQuantity = stockQuantity
                };
                _context.Stocks.Add(stock);
            }
            await _context.SaveChangesAsync();
     
            return await _context.Stocks.Where(x => x.ProductId  == productId).ToListAsync();

        }
        private async Task<bool> ProductExist(int productId )
        {
            return await _context.Products.AnyAsync(x => x.Id == productId );
        }

    }
}
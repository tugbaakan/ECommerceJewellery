using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ShopperController : BaseAPIController
    {
        private readonly DataContext _context;

        public ShopperController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("initializecart")]
        public async Task<ActionResult<Cart>> InitializeCart()
        {
            /*check if a cart is initialzed*/
            if ( await _context.Carts.AnyAsync())
                return await _context.Carts.FirstOrDefaultAsync();
        
            var cart = new Cart();
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            
            return cart; 
        }

        [HttpPost("addtocart")] 
        public async Task<ActionResult<IEnumerable<Carty>>> AddToCart(int cartId, int productId, int productQuantity)
        {
            // check if the cart Id is correct
            if (! await CartExist(cartId)) return BadRequest("There is no such cart");   
            
            // check if the product Id is correct
            if (! await ProductExist(productId)) return BadRequest("There is no such product");

            //check if the product exist in the stock
            if (! await ProductExistStock(productId)) return BadRequest("The product is not available");

            //check if the product exist in the cart
            if ( await ProductExistCart(productId, cartId))
            {
                // update the existing record
                await UpdateCarty(cartId, productId, productQuantity);
            } 
            else 
            {
                await InsertCarty(cartId, productId, productQuantity);
            }

            return await _context.Carties.Where(x =>  x.CartId == cartId).ToListAsync();
        
        }

        private async Task<bool> CartExist(int cartId )
        {
            return await _context.Carts.AnyAsync(x => x.Id == cartId );
        }
        private async Task<bool> ProductExist(int productId )
        {
            return await _context.Products.AnyAsync(x => x.Id == productId );
        }
        private async Task<bool> ProductExistStock(int productId )
        {

            if ( await _context.Stocks.AnyAsync(x => x.ProductId == productId ) )
            {
                var stock = _context.Stocks.Where(x => x.ProductId == productId ).FirstOrDefault();
                if ( stock.StockQuantity > 0 )
                    return true;
                return false;
            }  
            return false;       
        }
        private async Task<bool> ProductExistCart(int productId, int cartId)
        {
            if ( await _context.Carties.AnyAsync(x => x.CartId == cartId && x.ProductId == productId ) )
            { 
                var carty = _context.Carties.Where(x => x.CartId == cartId && x.ProductId == productId ).FirstOrDefault();
                if ( carty.Quantity > 0 )
                    return true;
                return false;
            }
            return false;
        }

        private async Task<bool> UpdateCarty( int cartId, int productId, int quantity)
        {
            if ( await _context.Carties.AnyAsync(x => x.CartId == cartId && x.ProductId == productId ) )
            { 
                var updatedCarty = _context.Carties.FirstOrDefault(x => x.CartId == cartId && x.ProductId == productId );
                //.Where(x => x.CartId == cartId && x.ProductId == productId ).FirstOrDefault();
                if ( updatedCarty.Quantity > 0 )
                {
                    updatedCarty.Quantity = updatedCarty.Quantity + quantity;
                    _context.Carties.Update(updatedCarty);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        private async Task<bool> InsertCarty(int cartId, int productId, int quantity)
        {
            var carty = new Carty
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };
            _context.Carties.Add(carty);
            await _context.SaveChangesAsync();
            return true;
        }

        
       
    }
}
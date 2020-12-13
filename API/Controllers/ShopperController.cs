using System.Collections.Generic;
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
        public async Task<ActionResult<Carty>> AddToCart(int cartId, int productId, int productQuantity)
        {
            /* check if the cart Id is correct*/
            if (! await CartExist(cartId)) return BadRequest("There is no such cart");   
            
            /* check if the product Id is correct*/
            if (! await ProductExist(productId)) return BadRequest("There is no such product");

            var carty = new Carty
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = productQuantity
            };

            _context.Carties.Add(carty);
            await _context.SaveChangesAsync(); 
            
            return carty;

        }

        private async Task<bool> CartExist(int cartId )
        {
            return await _context.Carts.AnyAsync(x => x.Id == cartId );
        }   
        private async Task<bool> ProductExist(int productId )
        {
            return await _context.Products.AnyAsync(x => x.Id == productId );
        }

       
    }
}
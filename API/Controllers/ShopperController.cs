using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ShopperController : BaseAPIController
    {
        private readonly DataContext _context;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public ShopperController(DataContext context, ICartRepository cartRepository, IProductRepository productRepository)
        {
            _context = context;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        [HttpPost("initializecart")]
        public async Task<ActionResult<Cart>> InitializeCart()
        {
            /*check if a cart is initialzed*/
            if ( await _cartRepository.AnyCartExist() )
                return Ok();
            
            await _cartRepository.AddCart();
            await _cartRepository.SaveAllAsync();
            
            return Ok(); 
        }

        [HttpPost("addtocart")] 
        public async Task<ActionResult<IEnumerable<Carty>>> AddToCart(int cartId, int productId, int productQuantity)
        {
            // check if the cart Id is correct
            if (! await _cartRepository.CartExist(cartId)) return  BadRequest("There is no such cart");   
            
            // check if the product Id is correct
            if (! await _productRepository.ProductExist(productId)) return BadRequest("There is no such product");

            //check if the product exist in the stock
            if (! await _productRepository.ProductExistStock(productId)) return BadRequest("The product is not available");

            _cartRepository.AddCarty( cartId, productId, productQuantity);
  
            if (await _cartRepository.SaveAllAsync())
            {
                var cart = await _cartRepository.GetCartAsync(cartId);
                return Ok(); // cart.Carties;
            }
            
            return BadRequest("Failed to add to cart");
        
        }
       
    }
}
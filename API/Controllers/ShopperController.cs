using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ShopperController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ShopperController(IUnitOfWork unitOfWork , IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("initializecart")]
        public async Task<ActionResult<Cart>> InitializeCart()
        {
            /*check if a cart is initialzed*/
            if ( await _unitOfWork.CartRepository.AnyCartExist() )
                return Ok();
            
            await _unitOfWork.CartRepository.AddCart();
            await _unitOfWork.Complete() ;
            
            return Ok(); 
        }

        [HttpPost("addtocart")] 
        public async Task<ActionResult<CartDto>> AddToCart(int cartId, int productId, int productQuantity)
        {
            // check if the cart Id is correct
            if (! await _unitOfWork.CartRepository.CartExist(cartId)) return  BadRequest("There is no such cart");   
            
            // check if the product Id is correct
            if (! await _unitOfWork.ProductRepository.ProductExist(productId)) return BadRequest("There is no such product");
           
            //check if the product available in stock
            var quantityCart = await _unitOfWork.CartRepository.GetProductQuantityInCart(cartId, productId);
            if (! await _unitOfWork.StockRepository.ProductExistStock(productId, quantityCart + productQuantity)) return BadRequest("The product is not available in stock");
      
            _unitOfWork.CartRepository.AddCarty( cartId, productId, productQuantity);
  
            if (await _unitOfWork.Complete())
            {
                var cart = await _unitOfWork.CartRepository.GetCartAsync(cartId);
                return Ok(cart); // cart.Carties;
            }
            
            return BadRequest("Failed to add to cart");
        
        }

        [HttpPost("removefromcart")] 
        public async Task<ActionResult<CartDto>> RemoveFromCart(int cartId, int productId)
        {
            // check if the cart Id is correct
            if (! await _unitOfWork.CartRepository.CartExist(cartId)) return  BadRequest("There is no such cart");   
            
            // check if the product Id is correct
            if (! await _unitOfWork.ProductRepository.ProductExist(productId)) return BadRequest("There is no such product");
           
            //check if the product exist in cart
            if (! await _unitOfWork.CartRepository.ProductExistCart(cartId, productId)) return BadRequest("There is no such product in the cart");
        
            _unitOfWork.CartRepository.RemoveCarty( cartId, productId);
  
            if (await _unitOfWork.Complete())
            {
                var cart = await _unitOfWork.CartRepository.GetCartAsync(cartId);
                return Ok(cart); // cart.Carties;
            }
            
            return BadRequest("Failed to remove from cart");

        }
       
    }
}
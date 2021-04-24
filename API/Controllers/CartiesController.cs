using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CartiesController: BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartiesController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carty>>> GetCarties()
        {
            var carties =  await _unitOfWork.CartyRepository.GetAll();
            return Ok(carties);
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<Carty>> GetCartyById(int id)
        {
            var carty =  await _unitOfWork.CartyRepository.GetById(id);
            return Ok(carty);
        }

        [HttpPost("addtocart")] 
        public async Task<ActionResult> AddToCart([FromQuery] int cartId, int productId, int quantity )
        {
            // check if the cart Id is correct
            var cart = await _unitOfWork.CartRepository.GetById(cartId);
            if(cart == null)
                return  BadRequest("There is no such cart");   
            
            // check if the product Id is correct
            var product = await _unitOfWork.ProductRepository.GetById(productId);
            if(product == null)
                return BadRequest("There is no such product");

            var cartyToBeUpdated = await _unitOfWork.CartyRepository.GetCartyByCartIdProductId(cartId, productId);
            if (cartyToBeUpdated != null)
            {
                var QuantityDesired = cartyToBeUpdated.Quantity + quantity;
                //check if the product available in stock
                if(product.Quantity < QuantityDesired)
                    return BadRequest("The desired amount is not available!");

                cartyToBeUpdated.Quantity += quantity;
                _unitOfWork.CartyRepository.Update(cartyToBeUpdated);
            }
            else
            {
                //check if the product available in stock
                if(product.Quantity < quantity)
                    return BadRequest("The desired amount is not available!");

                var cartyNew = new Carty{
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = quantity
                };

                _unitOfWork.CartyRepository.Add(cartyNew);
            }

            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The product could not be added o the cart!");
   
        
        }

        [HttpPost("removefromcart")] 
        public async Task<ActionResult> RemoveFromCart(int cartId, int productId)
        {
            // check if the cart Id is correct
            var cart = await _unitOfWork.CartRepository.GetById(cartId);
            if(cart == null)
                return  BadRequest("There is no such cart");   
                
            //check if the product exist in cart
            var cartyToBeDeleted = await _unitOfWork.CartyRepository.GetCartyByCartIdProductId(cartId, productId);
            if (cartyToBeDeleted == null)
                return BadRequest("There is no such product in the cart");
        
            _unitOfWork.CartyRepository.Remove(cartyToBeDeleted);

            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The product could not be removed from the cart!");

        }

    }
}


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
    public class CartsController: BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartsController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            var carts =  await _unitOfWork.CartRepository.GetAll();
            return Ok(carts);
        }


        [HttpGet("{cartId}")]
        public async Task<ActionResult<CartDto>> GetCartById(int cartId)
        {
            return await _unitOfWork.CartRepository.GetCartById(cartId);
        }

        [HttpPost("initializecart")]
        public async Task<ActionResult<Cart>> InitializeCart()
        {
            /*check if a cart is initialzed*/
            var carts = await _unitOfWork.CartRepository.GetAll();
            
            if(carts.FirstOrDefault() != null )
                return Ok();

            var cart = new Cart();
            
            _unitOfWork.CartRepository.Add(cart);

            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The cart could not be initialized!");

        }

    }
}
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
            var carts =  await _unitOfWork.CartRepository.GetCartsAsync();
            return Ok(carts);
        }


        [HttpGet("{cartId}")]
        public async Task<ActionResult<CartDto>> GetCart(int cartId)
        {
            return await _unitOfWork.CartRepository.GetCartAsync(cartId);
        }

    }
}
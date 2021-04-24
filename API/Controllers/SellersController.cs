using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SellersController: BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellersController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSellers()
        {
            var sellers =  await _unitOfWork.SellerRepository.GetSellers();
            return Ok(sellers);
        }
    
        [HttpPost("add")]
        public async Task<ActionResult<Seller>> AddSeller(SellerCreateDto sellerDto)
        {
            var user = await _unitOfWork.UserRepository.GetById(sellerDto.UserId);
            if ( user == null )
                return BadRequest("There is no such a user!");

            var seller = await _unitOfWork.SellerRepository.GetSellerByUserId(sellerDto.UserId);
            if ( seller != null )
                return BadRequest("There is already a seller created from that user!");

            var sellerNew = new Seller{
                UserId = sellerDto.UserId,
                Name = sellerDto.Name.ToLower(),
                City = sellerDto.City
            }; 

            _unitOfWork.SellerRepository.Add(sellerNew); 
           
            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The seller could not be added!");
           
        }


    }
}
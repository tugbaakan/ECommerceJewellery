using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UsersController : BaseAPIController
    {        
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork  )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            return Ok(users);
        }

        [Authorize]
        // api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            return Ok(user);
        }
  
        [AllowAnonymous]
        [HttpPost("add/{name}")]
        public async Task<ActionResult<AppUser>> AddUser(string name)
        {
            var user = await _unitOfWork.UserRepository.GetUserByName(name);
            if ( user != null )
                return BadRequest("There is a user with the this name already!");

            var userNew = new AppUser{
                UserName = name.ToLower()
            };

            _unitOfWork.UserRepository.Add(userNew); 
           
            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The user could not be added!");
           
        }


    }
}
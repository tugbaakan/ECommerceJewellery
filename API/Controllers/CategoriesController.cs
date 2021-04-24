using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriesController: BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork  )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories =  await _unitOfWork.CategoryRepository.GetAll();
            return Ok(categories);
        }
    
        [HttpPost("add/{name}")]
        public async Task<ActionResult> AddCategory(string name)
        {
            var category = await _unitOfWork.CategoryRepository.GetCategoryByName(name.ToLower());
            if(category != null)
                return BadRequest("There is a category with the this name already!");

            var categoryNew = new Category{
                Name = name.ToLower()
            };

            _unitOfWork.CategoryRepository.Add(categoryNew); 
           
            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The category could not be added!");
        }

    }
}
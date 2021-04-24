using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductTypesController: BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductTypesController(IUnitOfWork unitOfWork  )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeDto>>> GetProductTypes()
        {
            var productTypes =  await _unitOfWork.ProductTypeRepository.GetAll();
            return Ok(productTypes);
        }

        // api/products/productId
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
        {
            return await _unitOfWork.ProductTypeRepository.GetById(id);
        }
    
        [HttpPost("add")]
        public async Task<ActionResult> AddProductType([FromQuery] int categoryId, string name )
        {
            var category = await _unitOfWork.CategoryRepository.GetById(categoryId);
            if(category == null)
                return BadRequest("There is no such category!");

            var products = await _unitOfWork.ProductTypeRepository.GetProductTypesByCategoryId(categoryId);
            foreach(ProductType item in products)
            {
                if (item.Name == name)
                    return BadRequest("There is a product with the same name in this category!");
            }                

            var productTypeNew = new ProductType{
                CategoryId = categoryId,
                Name = name
            };

            _unitOfWork.ProductTypeRepository.Add(productTypeNew);
            
            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The product type could not be added!");

        }
    }
}
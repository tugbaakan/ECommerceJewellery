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
    public class ProductsController: BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork  )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products =  await _unitOfWork.ProductRepository.GetProducts();
            return Ok(products);
        }

        // api/products/productId
        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            return await _unitOfWork.ProductRepository.GetProductById(productId);
        }
    
        [HttpPost("add")]
        public async Task<ActionResult> AddProduct([FromQuery] int productTypeId, int sellerId, string name, int quantity )
        {
            var productType = await _unitOfWork.ProductTypeRepository.GetProductTypeById(productTypeId);
            if(productType == null)
                return BadRequest("There is no such product type!");
            
            var seller = await _unitOfWork.SellerRepository.GetSellerById(sellerId);
            if(seller == null)
                return BadRequest("There is no such seller!");

            var product = await _unitOfWork.ProductRepository.GetProductByProductTypeIdSellerId( productTypeId, sellerId);
            if(product != null)
                return BadRequest("There is a product with the same category and product type!");
            
            var productNew = new Product {
                ProductTypeId = productTypeId,
                SellerId = sellerId,
                Name = name,
                Quantity = quantity
            };

            _unitOfWork.ProductRepository.AddProduct(productNew);
            
            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The product could not be added!");

        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateProduct([FromQuery] int productTypeId, int sellerId, int quantity )
        {
            var productType = await _unitOfWork.ProductTypeRepository.GetProductTypeById(productTypeId);
            if(productType == null)
                return BadRequest("There is no such product type!");
            
            var seller = await _unitOfWork.SellerRepository.GetSellerById(sellerId);
            if(seller == null)
                return BadRequest("There is no such seller!");

            var product = await _unitOfWork.ProductRepository.GetProductByProductTypeIdSellerId( productTypeId, sellerId);
            if(product == null)
                return BadRequest("There is no such product!");

            product.Quantity += quantity;
            
            _unitOfWork.ProductRepository.UpdateProduct(product);
            
            if ( await _unitOfWork.Complete() )
                return Ok();
            return BadRequest("The product could not be updated!");

        }

    }
}
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
    public class ProductsController: BaseAPIController
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products =  await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        // api/products/productId
        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            return await _productRepository.GetProductAsync(productId);
        }

        [HttpPost()]
        public async Task<ActionResult> PostProduct(string productName, string productDescription = null )
        {
            _productRepository.AddProduct( productName, productDescription);
            if ( await _productRepository.SaveAllAsync())
                return Ok();

            return BadRequest("post product hata");

        }

    }
}
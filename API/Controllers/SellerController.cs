using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SellerController: BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellerController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("addproductstock")]
        public async Task<ActionResult<Stock>> AddProductStock(int productId, int stockQuantity)
        {
            // check if the product Id is correct
            if (! await _unitOfWork.ProductRepository.ProductExist(productId)) return BadRequest("There is no such product");

            var stockNew = await _unitOfWork.StockRepository.AddtoStock(productId, stockQuantity);

            await _unitOfWork.Complete();
     
            return Ok(stockNew);

        }

        [HttpGet("getstocks")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {

            var stocks = await _unitOfWork.StockRepository.GetStocksAsync();
            return Ok(stocks);
 
        }

    }
}
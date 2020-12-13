using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CartiesController: BaseAPIController
    {
        private readonly DataContext _context;

        public CartiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carty>>> GetCarties()
        {
            return await _context.Carties.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carty>> GetCarty(int id)
        {
            return await _context.Carties.FindAsync(id);
        }

        /*[HttpPut()]
        public async Task<ActionResult<Carty>> PutCarty([FromBody] Carty carty)
        {
            _context.Carties.Add(carty);
            await _context.SaveChangesAsync();

            return carty;
        }*/
        [HttpPut()]
        public async Task<ActionResult<Carty>> PutCarty(int cartId, int productId, int productQuantity)
        {
            var carty = new Carty{
                CartId = cartId,
                ProductId = productId,
                Quantity = productQuantity
            };

            _context.Carties.Add(carty);
            await _context.SaveChangesAsync();

            return carty;
        }



    }
}


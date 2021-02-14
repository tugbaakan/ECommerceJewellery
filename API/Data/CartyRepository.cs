using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CartyRepository : ICartyRepository
    { 
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CartyRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<Carty>> GetCarties()
        {
            return await _context.Carties.ToListAsync();
        }
        
        public async Task<Carty> GetCartyById(int cartyId)
        {
            return await _context.Carties.FindAsync(cartyId);
        }
        public async Task<Carty> GetCartyByCartIdProductId(int cartId, int productId)
        {
            return await _context.Carties.SingleOrDefaultAsync(x => x.CartId == cartId 
                && x.ProductId == productId);

        }
        public void AddCarty(Carty carty)
        {
            _context.Carties.Add(carty);
        }
        public void UpdateCarty(Carty carty)
        {
            _context.Carties.Update(carty);
        }       
        public void DeleteCarty(Carty carty)
        {
            _context.Carties.Remove(carty);
        }
              
        /* public async Task<bool> ProductExistCart(int cartId, int productId)
        {
            var cart = await GetCartWithCartiesById(cartId);
            if ( cart.Carties.Any(x => x.ProductId == productId && x.Quantity > 0) )
                return true;
            return false;

        }

        public async Task<int> GetProductQuantityInCart(int cartId, int productId)
        {
            var cart = await GetCartWithCartiesById(cartId);

            if ( cart.Carties != null && cart.Carties.Any( x => x.ProductId == productId ))
            {
                return cart.Carties.FirstOrDefault(x => x.ProductId == productId).Quantity;
            }  
            else 
            {
                return 0;
            }

        }  */
       

 
    }
}
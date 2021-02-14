using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CartRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<Cart>> GetCarts()
        {
             return await _context.Carts.ToListAsync();
        }

        // dont call it from the web page, use it as internal
        public async Task<Cart> GetCartWithCartiesById(int cartId)
        {
            return await _context.Carts
                .Include( c => c.Carties)
                .SingleOrDefaultAsync(c => c.Id == cartId);
        }
        public async Task<CartDto> GetCartById(int cartId)
        {
            //return await _context.Carts.FindAsync(cartId);
            
            return await _context.Carts
                .Where(x => x.Id == cartId)
                .ProjectTo<CartDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        }

        public void AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
        }
        public void DeleteCart(Cart cart)
        {
            _context.Carts.Remove(cart);
        }


    }
}
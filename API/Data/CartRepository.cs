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
    public class CartRepository : SQLiteBaseRepository<Cart>, ICartRepository
    {
        private DataContext DataContext_var
        {
            get { return _context as DataContext; }
        }
        private readonly IMapper _mapper;
        public CartRepository(DataContext context, IMapper mapper): base(context)
        {
            _mapper = mapper;
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

    }
}
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
        public async Task<IEnumerable<Cart>> GetCartsAsync()
        {
             return await _context.Carts.ToListAsync();
        }

        // dont call it from the web page, use it as internal
        public async Task<Cart> GetCartWithCartiesAsync(int cartId)
        {
            return await _context.Carts
                .Include( c => c.Carties)
                .SingleOrDefaultAsync(c => c.Id == cartId);
        }
        public async Task<CartDto> GetCartAsync(int cartId)
        {
            //return await _context.Carts.FindAsync(cartId);
            
            return await _context.Carts
                .Where(x => x.Id == cartId)
                .ProjectTo<CartDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        }
        public async Task<bool> AnyCartExist()
        {
            if( await _context.Carts.AnyAsync() )
                return true;
            return false;

        }
        public async Task AddCart()
        {
            var cart = new Cart();
            await _context.Carts.AddAsync(cart);
        }
        public async Task<bool> CartExist(int cartid)
        {
            if( await _context.Carts.AnyAsync( x => x.Id == cartid) )
                return true;
            return false;
        }

        public async Task<int> GetProductQuantityInCart(int cartId, int productId)
        {
            var cart = await _context.Carts
                .Include(c => c.Carties)
                .SingleOrDefaultAsync(c => c.Id == cartId);

            if ( cart.Carties != null && cart.Carties.Any( x => x.ProductId == productId))
            {
                return cart.Carties.FirstOrDefault(x => x.ProductId == productId).Quantity;
            }  
            else 
            {
                return 0;
            }

        }
        public async void AddCarty(int cartId, int productId, int productQuantity)
        {

            var cart = await _context.Carts
                .Include(c => c.Carties)
                .SingleOrDefaultAsync(c => c.Id == cartId);

            if ( cart.Carties != null && cart.Carties.Any( x => x.ProductId == productId))
            {
                // update the existing record
                var cartyUpdated = cart.Carties.FirstOrDefault(x => x.ProductId == productId);
                var finalQuantity = cartyUpdated.Quantity + productQuantity;
                cartyUpdated.Quantity = finalQuantity;

            }  
            else 
            {
                var carty = new Carty
                {
                    ProductId=productId,
                    Quantity = productQuantity
                };
                cart.Carties.Add(carty);
            }
        }
        public async Task<bool> ProductExistCart(int cartId, int productId)
        {
            var cart = await GetCartWithCartiesAsync(cartId);
            if ( cart.Carties.Any(x => x.ProductId == productId ) )
            { 
                var carty = cart.Carties.Where( x => x.ProductId == productId).FirstOrDefault();
                if ( carty.Quantity > 0 )
                    return true;
                return false;
            }
            return false;

        }

        public async void RemoveCarty(int cartId, int productId)
        {
            var cart = await _context.Carts
                .Include(c => c.Carties)
                .SingleOrDefaultAsync(c => c.Id == cartId);

            var cartyDeleted = cart.Carties.FirstOrDefault(x => x.ProductId == productId);
            cart.Carties.Remove(cartyDeleted);

        }

    }
}
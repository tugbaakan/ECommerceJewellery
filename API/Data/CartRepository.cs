using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        public CartRepository(DataContext context)
        {
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
        public async Task<Cart> GetCartAsync(int cartId)
        {
            return await _context.Carts.FindAsync(cartId);
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
        public async void AddCarty(int cartId, int productId, int productQuantity)
        {

            var cart = await _context.Carts
                .Include(c => c.Carties)
                .SingleOrDefaultAsync(c => c.Id == cartId);

            if ( cart.Carties != null)
            { 
                if ( cart.Carties.Any( x => x.ProductId == productId) )
                {
                    // update the existing record
                    var cartyUpdated = cart.Carties.FirstOrDefault(x => x.ProductId == productId);
                    cartyUpdated.Quantity = cartyUpdated.Quantity + productQuantity;
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
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateCart(Cart cart)
        {
             _context.Entry(cart).State = EntityState.Modified;
        }
    }
}
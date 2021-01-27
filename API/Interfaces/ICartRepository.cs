using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetCartsAsync();
        Task<CartDto> GetCartAsync(int cartId);
        Task<Cart> GetCartWithCartiesAsync(int cartId);
        Task<bool> AnyCartExist();
        Task<bool> CartExist(int cartid);
        Task AddCart();
        Task<int> GetProductQuantityInCart(int cartId, int productId);
        Task<bool> ProductExistCart(int productId, int cartId);
        void AddCarty(int cartId, int productId, int productQuantity);
        void RemoveCarty( int cartId, int productId);
      
    }
}
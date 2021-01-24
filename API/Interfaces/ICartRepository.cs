using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetCartsAsync();
        Task<Cart> GetCartAsync(int cartId);
        Task<Cart> GetCartWithCartiesAsync(int cartId);
        Task<bool> SaveAllAsync();
        Task<bool> AnyCartExist();
        Task<bool> CartExist(int cartid);
        Task AddCart();
        void AddCarty(int cartId, int productId, int productQuantity);
        void UpdateCart(Cart cart);
    }
}
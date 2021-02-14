using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetCarts();
        Task<Cart> GetCartWithCartiesById(int cartId);
        Task<CartDto> GetCartById(int cartId);
        void AddCart(Cart cart);
        void DeleteCart(Cart cart);
      
    }
}
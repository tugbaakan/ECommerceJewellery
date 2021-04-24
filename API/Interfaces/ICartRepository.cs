using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICartRepository: IGenericRepository<Cart>
    {
        Task<CartDto> GetCartById(int cartId);
        Task<Cart> GetCartWithCartiesById(int cartId);
      
    }
}
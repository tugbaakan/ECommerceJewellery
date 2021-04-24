using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ISellerRepository: IGenericRepository<Seller>
    {

        Task<IEnumerable<SellerDto>> GetSellers();
        Task<Seller> GetSellerByUserId(int userId);
        Task<Seller> GetSellerByName(string name);
  
    }
}
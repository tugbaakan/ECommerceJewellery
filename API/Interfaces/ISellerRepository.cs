using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ISellerRepository
    {
        Task<IEnumerable<SellerDto>> GetSellers();
        Task<Seller> GetSellerById(int sellerId);
        Task<Seller> GetSellerByUserId(int userId);
        Task<Seller> GetSellerByName(string name);
        void AddSeller(Seller seller);
        void UpdateSeller(Seller seller);
        void DeleteSeller(Seller seller);
    }
}
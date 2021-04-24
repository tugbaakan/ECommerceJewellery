using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByProductTypes (int productTypeId);
        Task<IEnumerable<Product>> GetProductsBySellerId(int sellerId);
        Task<Product> GetProductByName (string name);
        Task<Product> GetProductByProductTypeIdSellerId (int productTypeId, int sellerId);
   

    }
}
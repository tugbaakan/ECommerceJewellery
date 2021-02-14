using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductTypeDto>> GetProductTypes();
        Task<IEnumerable<ProductType>> GetProductTypesByCategoryId (int categoryId);
        Task<ProductType> GetProductTypeById(int productId);
        Task<ProductType> GetProductTypeByName (string name);
        void AddProductType(ProductType productType);
        void UpdateProductType(ProductType productType);
        void DeleteProductType(ProductType productType);
    }
}
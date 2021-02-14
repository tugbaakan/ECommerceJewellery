using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<IEnumerable<Product>> GetProductsByProductTypes (int productTypeId);
        Task<IEnumerable<Product>> GetProductsBySellerId(int sellerId);
        Task<Product> GetProductById(int productId);
        Task<Product> GetProductByName (string name);
        Task<Product> GetProductByProductTypeIdSellerId (int productTypeId, int sellerId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);

    }
}
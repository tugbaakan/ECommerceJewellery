using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int productId);
        Task<bool> ProductExist(int productId);
        Task<bool> ProductExistStock(int productId);
        Task<bool> ProductExistCart(int productId, int cartId);
        void AddProduct(string productName, string productDescription = null);
        void UpdateProduct(string productName, string productDescription = null);
        Task<bool> SaveAllAsync();
    }
}
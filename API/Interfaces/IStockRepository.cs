using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocksAsync();
        Task<Stock> GetStockAsync(int stockId);
        Task<Stock> AddtoStock(int productId, int productQuantity);
        Task<bool> ProductExistStock(int productId, int productQuantity);
        
    }
}
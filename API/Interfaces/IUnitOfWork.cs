using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        ICartRepository CartRepository {get; }
        IProductRepository ProductRepository  {get;}
        IStockRepository StockRepository {get; }
        Task<bool> Complete();
        bool HasChanges();
    }
} 
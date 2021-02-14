using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository {get; }
        IProductTypeRepository ProductTypeRepository {get; }
        IUserRepository UserRepository {get; }
        ISellerRepository SellerRepository {get; }
        IProductRepository ProductRepository {get; }
        ICartRepository CartRepository {get; }
        ICartyRepository CartyRepository {get; }
        Task<bool> Complete();
        bool HasChanges();
    }
} 
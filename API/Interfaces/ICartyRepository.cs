using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ICartyRepository
    {
        Task<IEnumerable<Carty>> GetCarties();
        Task<Carty> GetCartyById(int cartyId);
        Task<Carty> GetCartyByCartIdProductId(int cartId, int productId);
        void AddCarty(Carty carty);
        void UpdateCarty(Carty carty);
        void DeleteCarty(Carty carty);
        
    }
}
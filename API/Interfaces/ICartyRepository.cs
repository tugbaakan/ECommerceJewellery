using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ICartyRepository
    {
        Task<IEnumerable<Carty>> GetCartiesAsync();
        Task<Carty> GetCartyAsync(int cartyId);
        Task<bool> SaveAllAsync();
        void UpdateCarty(Carty carty);
        Task<bool> AnyCartyExist();
        Task<bool> CartyExist(int cartyId);
        void AddCarty(Carty carty);
    }
}
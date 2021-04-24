using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ICartyRepository: IGenericRepository<Carty>
    {
        Task<Carty> GetCartyByCartIdProductId(int cartId, int productId);
        
    }
}
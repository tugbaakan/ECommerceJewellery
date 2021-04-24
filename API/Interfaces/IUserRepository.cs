using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository: IGenericRepository<AppUser>
    {

        Task<AppUser> GetUserByName (string name);
        
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetUsers();
        Task<AppUser> GetUserById(int userId);
        Task<AppUser> GetUserByName (string name);
        void AddUser(AppUser user);
        void UpdateUser (AppUser user);
        void DeleteUser (AppUser user);
    }
}
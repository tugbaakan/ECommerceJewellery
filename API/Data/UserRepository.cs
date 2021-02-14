using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<AppUser> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<AppUser> GetUserByName(string name)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == name);
        }

        public void AddUser(AppUser user)
        {
            _context.Users.Add(user);
        }
        public void UpdateUser(AppUser user)
        {
            _context.Users.Update(user);
        }
        public void DeleteUser(AppUser user)
        {
            _context.Users.Remove(user);
        }


    }
}
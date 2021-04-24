using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository: SQLiteBaseRepository<AppUser>, IUserRepository
    {
        private DataContext DataContext_var
        {
            get { return _context as DataContext; }
        }
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper): base(context)
        {
            _mapper = mapper;
        }


        public async Task<AppUser> GetUserByName(string name)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == name);
        }


    }
}
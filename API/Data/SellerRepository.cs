using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SellerRepository: SQLiteBaseRepository<Seller>, ISellerRepository
    {
        private DataContext DataContext_var
        {
            get { return _context as DataContext; }
        }
        private readonly IMapper _mapper;
        public SellerRepository(DataContext context, IMapper mapper): base(context)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<SellerDto>> GetSellers()
        {
            return await _context.Sellers
                 .ProjectTo<SellerDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Seller> GetSellerByUserId(int userId)
        {
            return await _context.Sellers.SingleOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task<Seller> GetSellerByName(string name)
        {
            return await _context.Sellers.SingleOrDefaultAsync(x => x.Name == name);
        }




    }
}
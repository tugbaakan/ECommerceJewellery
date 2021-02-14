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
    public class SellerRepository: ISellerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SellerRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<SellerDto>> GetSellers()
        {
            return await _context.Sellers
                 .ProjectTo<SellerDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task<Seller> GetSellerById(int sellerId)
        {
            return await _context.Sellers.FindAsync(sellerId);
        }
        public async Task<Seller> GetSellerByUserId(int userId)
        {
            return await _context.Sellers.SingleOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task<Seller> GetSellerByName(string name)
        {
            return await _context.Sellers.SingleOrDefaultAsync(x => x.Name == name);
        }

        public void AddSeller(Seller seller)
        {
            _context.Sellers.Add(seller);
        }

        public void UpdateSeller(Seller seller)
        {
            _context.Sellers.Update(seller);
        }

        public void DeleteSeller(Seller seller)
        {
            _context.Sellers.Remove(seller);
        }


    }
}
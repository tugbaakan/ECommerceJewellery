using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : SQLiteBaseRepository<Product>, IProductRepository
    {
        private DataContext DataContext_var
        {
            get { return _context as DataContext; }
        }
        private readonly IMapper _mapper;
        public ProductRepository(DataContext context, IMapper mapper): base(context)
        {
            _mapper = mapper;

        }
        
        public async Task<IEnumerable<Product>> GetProductsByProductTypes(int productTypeId)
        {
            return await _context.Products.Where(x => x.ProductTypeId == productTypeId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySellerId(int sellerId)
        {
            return await _context.Products.Where(x => x.SellerId == sellerId).ToListAsync();

        }
        

        
        public async Task<Product> GetProductByName(string name)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Product> GetProductByProductTypeIdSellerId(int productTypeId, int sellerId)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.ProductTypeId == productTypeId
                && x.SellerId == sellerId );
        }


    }
}
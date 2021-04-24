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
    public class ProductTypeRepository : SQLiteBaseRepository<ProductType>, IProductTypeRepository
    {
        private DataContext DataContext_var
        {
            get { return _context as DataContext; }
        }
        private readonly IMapper _mapper;
        public ProductTypeRepository(DataContext context, IMapper mapper): base(context)
        {
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductType>> GetProductTypesByCategoryId(int categoryId)
        {
            return await _context.ProductTypes.Where( x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<ProductType> GetProductTypeByName(string name)
        {
            return await _context.ProductTypes.SingleOrDefaultAsync( x => x.Name == name);
        }
        


    }
}
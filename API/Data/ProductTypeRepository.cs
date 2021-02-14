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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductTypeRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<ProductTypeDto>> GetProductTypes()
        {
            return await _context.ProductTypes
                .ProjectTo<ProductTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesByCategoryId(int categoryId)
        {
            return await _context.ProductTypes.Where( x => x.CategoryId == categoryId).ToListAsync();
        }
        public async Task<ProductType> GetProductTypeById(int id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }
        public async Task<ProductType> GetProductTypeByName(string name)
        {
            return await _context.ProductTypes.SingleOrDefaultAsync( x => x.Name == name);
        }
        
        public void AddProductType(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
        }
        public void UpdateProductType(ProductType productType)
        {
            _context.ProductTypes.Update(productType);
        }
        public void DeleteProductType(ProductType productType)
        {
            _context.ProductTypes.Remove(productType);
        }

    }
}
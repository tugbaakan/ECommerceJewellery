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
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await _context.Products
                 .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByProductTypes(int productTypeId)
        {
            return await _context.Products.Where(x => x.ProductTypeId == productTypeId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySellerId(int sellerId)
        {
            return await _context.Products.Where(x => x.SellerId == sellerId).ToListAsync();

        }
        
        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.FindAsync(productId);
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
        public void AddProduct(Product product)
        {

            _context.Products.Add(product);
        
        }
        public void UpdateProduct(Product product)
        {

            _context.Products.Update(product);

        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

    }
}
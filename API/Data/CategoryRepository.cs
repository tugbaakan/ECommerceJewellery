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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            return await _context.Categories
                    .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                    .AsSingleQuery()
                    .ToListAsync();
        }
        public async Task<CategoryDto> GetCategoryById(int cateId)
        {
            return await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Id == cateId);
        }
        public async Task<CategoryDto> GetCategoryByName(string name)
        {
            return await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Name == name);
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }
        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }


    }
}
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
    public class CategoryRepository : SQLiteBaseRepository<Category>,  ICategoryRepository
    {
        private readonly IMapper _mapper;
        private DataContext DataContext_var
        {
            get { return _context as DataContext; }
        }
        public CategoryRepository(DataContext context, IMapper mapper) : base(context)
        {

            _mapper = mapper;
        }


        public async Task<CategoryDto> GetCategoryByName(string name)
        {
            return await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Name == name);
        }



    }
}
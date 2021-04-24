using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Task<CategoryDto> GetCategoryByName (string name);
    }
}
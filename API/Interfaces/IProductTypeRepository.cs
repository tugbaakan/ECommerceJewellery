using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductTypeRepository: IGenericRepository<ProductType>
    {

        Task<IEnumerable<ProductType>> GetProductTypesByCategoryId (int categoryId);
        Task<ProductType> GetProductTypeByName (string name);
    }
}
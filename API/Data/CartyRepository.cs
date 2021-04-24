using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CartyRepository : SQLiteBaseRepository<Carty>, ICartyRepository
    { 
        private DataContext DataContext_var
        {
            get { return _context as DataContext; }
        }
        private readonly IMapper _mapper;
        public CartyRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<Carty> GetCartyByCartIdProductId(int cartId, int productId)
        {
            return await _context.Carties.SingleOrDefaultAsync(x => x.CartId == cartId 
                && x.ProductId == productId);

        }
 
    }
}
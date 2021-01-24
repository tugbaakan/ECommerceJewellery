using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CartyRepository : ICartyRepository
    { 
        private readonly DataContext _context;
        public CartyRepository(DataContext context)
        {
            _context = context;
        }
        public void AddCarty(Carty carty)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AnyCartyExist()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CartyExist(int cartyId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Carty>> GetCartiesAsync()
        {
            return await _context.Carties.ToListAsync();
        }

        public Task<Carty> GetCartyAsync(int cartyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCarty(Carty carty)
        {
            throw new System.NotImplementedException();
        }
    }
}
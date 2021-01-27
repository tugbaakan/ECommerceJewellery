using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StockRepository: IStockRepository
    {
        private readonly DataContext _context;
        public StockRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Stock>> GetStocksAsync()
        {
            return await _context.Stocks.ToListAsync();
        }
        public async Task<Stock> GetStockAsync(int stockId)
        {
            return await _context.Stocks.FindAsync(stockId);
        }
        public async Task<Stock> AddtoStock(int productId, int productQuantity)
        {
            if ( await _context.Stocks.AnyAsync(x => x.ProductId == productId))
            {
                var stockUpdated = await _context.Stocks.SingleOrDefaultAsync(x => x.ProductId == productId);
                stockUpdated.StockQuantity = stockUpdated.StockQuantity + productQuantity;
                return stockUpdated;
            }
            else
            {
                var stockAdded = new Stock{
                    ProductId = productId,
                    StockQuantity = productQuantity
                };
                await _context.Stocks.AddAsync(stockAdded);
                return stockAdded;
            }    
        
        }
        public async Task<bool> ProductExistStock(int productId, int productQuantity)
        {
            if ( await _context.Stocks.AnyAsync(x => x.ProductId == productId) )
            {
                var stock = await _context.Stocks.SingleOrDefaultAsync(x => x.ProductId == productId );
                if ( stock.StockQuantity >= productQuantity )
                    return true;
                return false;
            }
            return false;

        }


    }
}
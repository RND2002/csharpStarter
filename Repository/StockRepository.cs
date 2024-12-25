using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using starterProject.Data;
using starterProject.Dtos.Stock;
using starterProject.Helper;
using starterProject.Interfaces;
using starterProject.Models;

namespace starterProject.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext ctx)
        {
            _context=ctx;
        }

        public async Task<Stock> createAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> deleteAsync(int id)
        {
            var stockModel=await _context.Stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(stockModel==null){
                return null;
            }
             _context.Stocks.Remove(stockModel);
             await _context.SaveChangesAsync();
             return stockModel;
        }

        // public async  Task<List<Stock>> getAllAsync()
        // {
        //     return await _context.Stocks.Include(c=>c.Comments).ToListAsync();
        //     //throw new NotImplementedException();
        // }
        public async Task<List<Stock>> getAllAsync(QueryObject query)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        // public Task<List<Stock>> getAllAsync(QueryObject queryObject)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<Stock?> getByIdAsync(int id)
        {
            return await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(i=>i.Id==id);
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(s=>s.Id==id);
        }

        public async Task<Stock?> updateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            var stockModel=await _context.Stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(stockModel==null){
                return null;
            }
            stockModel.CompanyName=updateStockRequestDto.CompanyName;
            stockModel.LastDue=updateStockRequestDto.LastDue;
            stockModel.MarketCap=updateStockRequestDto.MarketCap;
            stockModel.Symbol=updateStockRequestDto.Symbol;
            stockModel.Purchase=updateStockRequestDto.Purchase;

            await _context.SaveChangesAsync();

            return stockModel;

        }
    }
}
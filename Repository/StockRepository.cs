using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using starterProject.Data;
using starterProject.Dtos.Stock;
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

        public async  Task<List<Stock>> getAllAsync()
        {
            return await _context.Stocks.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<Stock?> getByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
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
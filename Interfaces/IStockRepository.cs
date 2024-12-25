using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using starterProject.Dtos.Stock;
using starterProject.Helper;
using starterProject.Models;

namespace starterProject.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> getAllAsync(QueryObject queryObject);

        Task<Stock?> getByIdAsync(int id);

        Task<Stock> createAsync(Stock stockModel);

        Task<Stock?> updateAsync(int id,UpdateStockRequestDto requestDto);

        Task<Stock?> deleteAsync(int id);

        Task<bool> StockExists(int id);
    }
}
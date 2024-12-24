using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using starterProject.Dtos.Stock;
using starterProject.Models;

namespace starterProject.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> getAllAsync();

        Task<Stock?> getByIdAsync(int id);

        Task<Stock> createAsync(Stock stockModel);

        Task<Stock?> updateAsync(int id,UpdateStockRequestDto requestDto);

        Task<Stock?> deleteAsync(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using starterProject.Dtos.Stock;
using starterProject.Models;

namespace starterProject.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel){
            return new StockDto{
                Id=stockModel.Id,
                Symbol=stockModel.Symbol,
                CompanyName=stockModel.CompanyName,
                Purchase=stockModel.Purchase,
                LastDue=stockModel.LastDue,
                MarketCap=stockModel.MarketCap
            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequest stockDto){
            return new Stock{
                Symbol=stockDto.Symbol,
                CompanyName=stockDto.CompanyName,
                MarketCap=stockDto.MarketCap,
                Purchase=stockDto.Purchase,
                LastDue=stockDto.LastDue,
                
            };
        }
        
    }
}
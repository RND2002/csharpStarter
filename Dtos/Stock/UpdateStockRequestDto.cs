using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starterProject.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
         public string Symbol {get;set;}=string.Empty;
        
        public string  CompanyName { get; set; }=string.Empty;

        
        public decimal Purchase { get; set; }

        
        public decimal LastDue { get; set; }

        
        public long MarketCap { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using starterProject.Dtos.Comment;

namespace starterProject.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }  //prop
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 over characters")]
        public string Symbol {get;set;}=string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Company Name cannot be over 10 over characters")]
        public string  CompanyName { get; set; }=string.Empty;

        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }

         [Required]
        [Range(0.001, 100)]
        public decimal LastDue { get; set; }

        [Range(1, 5000000000)]
        public long MarketCap { get; set; }

        public List<CommentDto> Comments {get;set;}
    }
}
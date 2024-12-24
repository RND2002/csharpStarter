using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace starterProject.Models
{
    public class Stock
    {
        public int Id { get; set; }  //prop

        public string Symbol {get;set;}=string.Empty;
        [Required]
        public string  CompanyName { get; set; }=string.Empty;

        [Column(TypeName ="decimal(18,2)")]
        public decimal Purchase { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal LastDue { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public long MarketCap { get; set; }

        public List<Comment> Comments {get;set;}=new List<Comment>();


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using starterProject.Models;

namespace starterProject.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) //ctor for constructor
        :base(dbContextOptions)   
        {
            
        }

        public DbSet<Stock> Stocks {get;set;}

        public DbSet<Comment> Comments {get;set;}
    }
}
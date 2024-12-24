using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using starterProject.Data;
using starterProject.Interfaces;
using starterProject.Models;

namespace starterProject.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context=context;
            
        }
        public async Task<List<Comment>> getAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
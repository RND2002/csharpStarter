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

        public async Task<Comment> CreateAsync(Comment comment)
        {
             await _context.AddAsync(comment);
             await _context.SaveChangesAsync();
             return comment;
        }

        public async Task<List<Comment>> getAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> getByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}
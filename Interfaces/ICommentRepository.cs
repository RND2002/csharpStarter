using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using starterProject.Models;

namespace starterProject.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> getAllAsync();

        Task<Comment?> getByIdAsync(int id);

        Task<Comment> CreateAsync(Comment comment);
    }
}
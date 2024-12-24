using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using starterProject.Interfaces;

namespace starterProject.Controller
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepository){
            _commentRepo=commentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getAll(){
            var comments=await _commentRepo.getAllAsync();
            return Ok(comments);
        }
             
    }
}
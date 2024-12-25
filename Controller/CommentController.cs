using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using starterProject.Dtos.Comment;
using starterProject.Interfaces;
using starterProject.Mappers;

namespace starterProject.Controller
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepository,IStockRepository stockRepository){
            _commentRepo=commentRepository;
            _stockRepo=stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comments=await _commentRepo.getAllAsync();
            var commentDtos=comments.Select(s=>s.toCommentResponse());
            return Ok(commentDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comment=await _commentRepo.getByIdAsync(id);

            if(comment==null){
                return NotFound();
            }
            return Ok(comment.toCommentResponse());
        }
        

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId,[FromBody] CreateCommentRequest createCommentRequest){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(!await _stockRepo.StockExists(stockId)){
                return BadRequest("Stock does not exists");
            }

            var comment=createCommentRequest.FromCommentMapperToComment(stockId);
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById),new {id=comment},comment.toCommentResponse());
        }
        
             
    }
}
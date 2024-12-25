using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using starterProject.Dtos.Comment;
using starterProject.Models;

namespace starterProject.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto toCommentResponse(this Comment comment){
            return new CommentDto{
                Title=comment.Title,
                Content=comment.Content,
                StockId=comment.StockId,
                CreatedOn=comment.CreatedOn,
                Id=comment.Id
            };
        }

        public static Comment FromCommentMapperToComment(this CreateCommentRequest createCommentRequest, int stockId) {
            return new Comment{
                StockId=stockId,
                Title=createCommentRequest.Title,
                Content=createCommentRequest.Content
            };
        } 
    }
}
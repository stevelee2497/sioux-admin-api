using DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<CommentOutputDto> Create([FromBody] CommentInputDto commentInputDto)
        {
            var userId = User.GetUserId();
            return _commentService.Create(commentInputDto, userId);
        }

        [HttpGet]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<IEnumerable<CommentOutputDto>> Get([FromHeader] IDictionary<string, string> @params)
        {
            return _commentService.Get(@params);
        }

        [HttpGet("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<CommentOutputDto> Get(Guid id)
        {
            return _commentService.Get(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Update(Guid id, [FromBody] CommentInputDto commentInputDto)
        {
            return _commentService.Update(id, commentInputDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _commentService.Delete(id);
        }
    }
}
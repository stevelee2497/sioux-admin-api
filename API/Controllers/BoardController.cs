using System;
using System.Collections.Generic;
using DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;

namespace API.Controllers
{
    [Route("api/boards")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<BoardOutputDto> Create([FromBody] BoardInputDto boardInputDto)
        {
            var userId = User.GetUserId();
            return _boardService.Create(boardInputDto, userId);
        }

        [HttpGet]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<IEnumerable<BoardOutputDto>> Get([FromHeader] IDictionary<string, string> @params)
        {
            var role = User.GetRole();
            return _boardService.Get(role, @params);
        }

        [HttpGet("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<BoardOutputDto> Get(Guid id)
        {
            return _boardService.Get(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Update([FromBody] BoardInputDto boardInputDto)
        {
            return _boardService.Update(boardInputDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _boardService.Delete(id);
        }
    }
}
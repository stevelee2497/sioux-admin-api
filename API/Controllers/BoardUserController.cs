using System;
using DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
    [Route("api/boardUsers")]
    public class BoardUserController : ControllerBase
    {
        private readonly IBoardUserService _boardUserService;

        public BoardUserController(IBoardUserService boardUserService)
        {
            _boardUserService = boardUserService;
        }

        [HttpPost]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<BoardUserOutputDto> Create([FromBody] BoardUserInputDto boardUserInputDto)
        {
            return _boardUserService.Create(boardUserInputDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _boardUserService.Delete(id);
        }
    }
}
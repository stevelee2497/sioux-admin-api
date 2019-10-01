using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
    [Route("api/userPositions")]
    public class UserPositionController : Controller
    {
        private readonly IUserPositionService _userPositionService;

        public UserPositionController(IUserPositionService userPositionService)
        {
            _userPositionService = userPositionService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Create([FromBody] UserPositionInputDto userPosition)
        {
            return _userPositionService.Create(userPosition);
        }

        [HttpPost("many")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<int> CreateMany([FromBody] List<UserPositionInputDto> userPositions)
        {
            return _userPositionService.CreateMany(userPositions);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _userPositionService.Delete(id);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
    [Route("api/positions")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost]
        [Produces("application/json")]
        public BaseResponse<PositionOutputDto> Create([FromBody] PositionInputDto position)
        {
            return _positionService.Create(position);
        }

        [HttpPost("many")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<PositionOutputDto>> CreateMany([FromBody] List<PositionInputDto> positions)
        {
            return _positionService.CreateMany(positions);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public BaseResponse<PositionOutputDto> Get(Guid id)
        {
            return _positionService.Get(id);
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<PositionOutputDto>> Where([FromHeader] IDictionary<string, string> @params)
        {
            return _positionService.Where(@params);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<PositionOutputDto> Update(Guid id, [FromBody] PositionInputDto position)
        {
            return _positionService.Update(id, position);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _positionService.Delete(id);
        }
    }
}
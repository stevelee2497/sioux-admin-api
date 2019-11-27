using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
    [Route("api/workLogs")]
    [ApiController]
    public class WorkLogController : ControllerBase
    {
        private readonly IWorkLogService _workLogService;

        public WorkLogController(IWorkLogService workLogService)
        {
            _workLogService = workLogService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<WorkLogOutputDto> Create([FromBody] WorkLogInputDto workLogInputDto)
        {
            return _workLogService.Create(workLogInputDto);
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<WorkLogOutputDto>> Where([FromHeader] IDictionary<string, string> @params)
        {
            return _workLogService.Where(@params);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<WorkLogOutputDto> Update(Guid id, [FromBody] WorkLogInputDto workLogInputDto)
        {
            return _workLogService.Update(id, workLogInputDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<WorkLogOutputDto> Delete(Guid id)
        {
            return _workLogService.Delete(id);
        }
    }
}
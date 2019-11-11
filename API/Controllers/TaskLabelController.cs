using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/taskLabels")]
    [ApiController]
    public class TaskLabelController : ControllerBase
    {
        private readonly ITaskLabelService _taskLabelService;

        public TaskLabelController(ITaskLabelService taskLabelService)
        {
            _taskLabelService = taskLabelService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<TaskLabelOutputDto> Create([FromBody] TaskLabelInputDto taskLabelInputDto)
        {
            return _taskLabelService.Create(taskLabelInputDto);
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<TaskLabelOutputDto>> Where([FromHeader] IDictionary<string, string> @params)
        {
            return _taskLabelService.Where(@params);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<TaskLabelOutputDto> Delete(Guid id)
        {
            return _taskLabelService.Delete(id);
        }
    }
}
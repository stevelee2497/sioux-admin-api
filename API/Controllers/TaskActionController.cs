using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
    [Route("api/taskActions")]
    [ApiController]
    public class TaskActionController : ControllerBase
    {
        private readonly ITaskActionService _taskActionService;

        public TaskActionController(ITaskActionService taskActionService)
        {
            _taskActionService = taskActionService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<TaskActionOutputDto> Create([FromBody] TaskActionInputDto taskAction)
        {
            return _taskActionService.Create(taskAction);
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<TaskActionOutputDto>> Where([FromHeader] IDictionary<string, string> @params)
        {
            return _taskActionService.Where(@params);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _taskActionService.Delete(id);
        }
    }
}
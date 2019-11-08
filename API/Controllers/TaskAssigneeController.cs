using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/taskAssignees")]
    [ApiController]
    public class TaskAssigneeController : ControllerBase
    {
        private readonly ITaskAssigneeService _taskAssigneeService;

        public TaskAssigneeController(ITaskAssigneeService taskAssigneeService)
        {
            _taskAssigneeService = taskAssigneeService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<TaskAssigneeOutputDto> Create([FromBody] TaskAssigneeInputDto taskAssignee)
        {
            return _taskAssigneeService.Create(taskAssignee);
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<TaskAssigneeOutputDto>> Where([FromHeader] IDictionary<string, string> @params)
        {
            return _taskAssigneeService.Where(@params);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<TaskAssigneeOutputDto> Delete(Guid id)
        {
            return _taskAssigneeService.Delete(id);
        }
    }
}
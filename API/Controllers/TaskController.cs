using DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<TaskOutputDto> Create([FromBody] TaskInputDto taskInputDto)
        {
            return _taskService.Create(taskInputDto);
        }

        [HttpGet]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<IEnumerable<TaskOutputDto>> Get([FromHeader] IDictionary<string, string> @params)
        {
            return _taskService.Get(@params);
        }

        [HttpGet("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<TaskOutputDto> Get(Guid id)
        {
            return _taskService.Get(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Update([FromBody] TaskInputDto taskInputDto)
        {
            return _taskService.Update(taskInputDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces(AppConstant.ContentType)]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _taskService.Delete(id);
        }
    }
}
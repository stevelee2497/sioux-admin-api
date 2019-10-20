using AutoMapper;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Extensions;
using Services.Extensions;

namespace Services.Implementations
{
    public class TaskService : EntityService<Task>, ITaskService
    {
        private readonly ITaskAssigneeService _taskAssigneeService;

        public TaskService(ITaskAssigneeService taskAssigneeService)
        {
            _taskAssigneeService = taskAssigneeService;
        }

        #region C

        public BaseResponse<TaskOutputDto> Create(TaskInputDto taskInputDto)
        {
            var task = Create(Mapper.Map<Task>(taskInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not create task {taskInputDto.Title}");
            }

            var assignees = taskInputDto.Assignees.Select(x => new TaskAssignee {UserId = x, TaskId = task.Id});
            _taskAssigneeService.CreateMany(assignees, out isSaved);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not assign task {taskInputDto.Title} to assignees");
            }

            return new SuccessResponse<TaskOutputDto>(Mapper.Map<TaskOutputDto>(task));
        }

        #endregion

        #region R

        public BaseResponse<IEnumerable<TaskOutputDto>> Get(IDictionary<string, string> @params)
        {
            var tasks = Where(@params.ToObject<TaskQuery>()).Select(x => Mapper.Map<TaskOutputDto>(x));
            return new SuccessResponse<IEnumerable<TaskOutputDto>>(tasks);
        }

        public BaseResponse<TaskOutputDto> Get(Guid id)
        {
            var task = First(x => x.IsActivated() && x.Id == id);
            return new SuccessResponse<TaskOutputDto>(Mapper.Map<TaskOutputDto>(task));
        }

        public IQueryable<Task> Where(TaskQuery query)
        {
            if (!string.IsNullOrEmpty(query.BoardId))
            {
                var boardId = Guid.Parse(query.BoardId);
                return Where(x => x.IsActivated() && x.BoardId == boardId);
            }

            return Where(x => x.IsActivated());
        }

        #endregion

        #region U

        public BaseResponse<bool> Update(TaskInputDto taskInputDto)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region D

        public BaseResponse<bool> Delete(Guid predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
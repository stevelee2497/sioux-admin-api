using AutoMapper;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;

namespace Services.Implementations
{
    public class TaskService : EntityService<Task>, ITaskService
    {
        private readonly IWorkLogService _workLogService;
        private readonly ITaskAssigneeService _taskAssigneeService;
        

        public TaskService(ITaskAssigneeService taskAssigneeService, IWorkLogService workLogService)
        {
            _taskAssigneeService = taskAssigneeService;
            _workLogService = workLogService;
        }

        #region C

        public BaseResponse<TaskOutputDto> Create(TaskInputDto taskInputDto)
        {
            var entity = Mapper.Map<Task>(taskInputDto);
            var taskKey = Count(x => x.BoardId == entity.BoardId) + 1;
            if (taskKey == 0)
            {
                throw new BadRequestException($"Could not create task {taskInputDto.Title}");
            }

            entity.TaskKey = taskKey;
            var task = Create(entity, out var isSaved);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not create task {taskInputDto.Title}");
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
            var task = Include(x => x.TaskAssignees).Include(x => x.TaskLabels).First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            return new SuccessResponse<TaskOutputDto>(Mapper.Map<TaskOutputDto>(task));
        }

        public IQueryable<Task> Where(TaskQuery query)
        {
            var linq = Include(x => x.TaskAssignees).Include(x => x.TaskLabels);

            if (!string.IsNullOrEmpty(query.BoardId))
            {
                var boardId = Guid.Parse(query.BoardId);
                return linq.Where(x => x.EntityStatus == EntityStatus.Activated && x.BoardId == boardId);
            }

            if (!string.IsNullOrEmpty(query.MemberId))
            {
                var memberId = Guid.Parse(query.MemberId);
                var taskAssigned = _taskAssigneeService.Include(x => x.Task).ThenInclude(x => x.WorkLogs).Where(x => x.UserId == memberId).Select(x => x.Task);
                var taskLogged = _workLogService.Include(x => x.Task).Where(x => x.UserId == memberId).Select(x => x.Task).GroupBy(x => x.Id).Select(x => x.First());
                return taskAssigned.Union(taskLogged).OrderBy(x => x.BoardId).ThenBy(x => x.TaskKey);
            }

            return linq.Where(x => x.EntityStatus == EntityStatus.Activated);
        }

        #endregion

        #region U

        public BaseResponse<bool> Update(TaskInputDto taskInputDto)
        {
            var task = Mapper.Map<Task>(taskInputDto);
            var isSaved = Update(task);
            if (!isSaved)
            {
                throw new BadRequestException("Could not update task");
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion

        #region D

        public BaseResponse<bool> Delete(Guid id)
        {
            var entity = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var isSaved = Delete(entity);
            if (!isSaved)
            {
                throw new BadRequestException("Could not delete task");
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion
    }
}
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
        #region C

        public BaseResponse<TaskOutputDto> Create(TaskInputDto taskInputDto)
        {
            var task = Create(Mapper.Map<Task>(taskInputDto), out var isSaved);
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
            var task = Include(x => x.TaskAssignees).First(x => x.IsActivated() && x.Id == id);
            return new SuccessResponse<TaskOutputDto>(Mapper.Map<TaskOutputDto>(task));
        }

        public IQueryable<Task> Where(TaskQuery query)
        {
            var linq = Include(x => x.TaskAssignees);

            if (!string.IsNullOrEmpty(query.BoardId))
            {
                var boardId = Guid.Parse(query.BoardId);
                return linq.Where(x => x.IsActivated() && x.BoardId == boardId);
            }

            return linq.Where(x => x.IsActivated());
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
            var entity = First(x => x.IsActivated() && x.Id == id);
            var isSaved = Delete(entity);
            return new SuccessResponse<bool>(isSaved);
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Enums;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;

namespace Services.Implementations
{
    public class TaskActionService : EntityService<TaskAction>, ITaskActionService
    {
        #region MyRegion

        public BaseResponse<TaskActionOutputDto> Create(TaskActionInputDto taskActionInputDto)
        {
            var taskAction = Create(Mapper.Map<TaskAction>(taskActionInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not update action for task {taskActionInputDto.TaskId}");
            }

            return new SuccessResponse<TaskActionOutputDto>(Mapper.Map<TaskActionOutputDto>(taskAction));
        }

        #endregion

        #region R

        public BaseResponse<IEnumerable<TaskActionOutputDto>> Where(IDictionary<string, string> @params)
        {
            var actions = Where(@params.ToObject<TaskActionQuery>()).OrderByDescending(x => x.CreatedTime).Select(x => Mapper.Map<TaskActionOutputDto>(x));
            return new SuccessResponse<IEnumerable<TaskActionOutputDto>>(actions);
        }

        private IQueryable<TaskAction> Where(TaskActionQuery queries)
        {
            if (!string.IsNullOrEmpty(queries.TaskId))
            {
                var taskId = Guid.Parse(queries.TaskId);
                return Where(x => x.EntityStatus == EntityStatus.Activated && x.TaskId == taskId);
            }

            return Where(x => x.EntityStatus == EntityStatus.Activated);
        }

        #endregion

        #region D

        public BaseResponse<bool> Delete(Guid id)
        {
            var action = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var isSaved = Delete(action);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not delete action {id}");
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion
    }
}
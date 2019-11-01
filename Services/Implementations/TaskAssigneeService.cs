using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Exceptions;
using DAL.Extensions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Implementations
{
    public class TaskAssigneeService : EntityService<TaskAssignee>, ITaskAssigneeService
    {
        public BaseResponse<TaskAssigneeOutputDto> Create(TaskAssigneeInputDto taskAssignee)
        {
            var entity = Create(Mapper.Map<TaskAssignee>(taskAssignee), out var isSaved);
            if (!isSaved)
            {
                throw new BadRequestException("Could not assign task to member");
            }

            return new SuccessResponse<TaskAssigneeOutputDto>(Mapper.Map<TaskAssigneeOutputDto>(entity));
        }

        public BaseResponse<IEnumerable<TaskAssigneeOutputDto>> Where(IDictionary<string, string> @params)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<bool> Delete(Guid id)
        {
            var entity = First(x => x.IsActivated() && x.Id == id);
            var isDeleted = DeletePermanent(entity);
            if (!isDeleted)
            {
                throw new BadRequestException("Could not remove member from task");
            }

            return new SuccessResponse<bool>(true);
        }
    }
}
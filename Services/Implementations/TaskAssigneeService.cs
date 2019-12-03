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
            var entities = Where(x => x.EntityStatus == EntityStatus.Activated).Select(x => Mapper.Map<TaskAssigneeOutputDto>(x));
            return new SuccessResponse<IEnumerable<TaskAssigneeOutputDto>>(entities);
        }

        public BaseResponse<TaskAssigneeOutputDto> Delete(Guid id)
        {
            var entity = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var isDeleted = DeletePermanent(entity);
            if (!isDeleted)
            {
                throw new BadRequestException("Could not remove member from task");
            }

            return new SuccessResponse<TaskAssigneeOutputDto>(Mapper.Map<TaskAssigneeOutputDto>(entity));
        }
    }
}
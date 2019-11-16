using AutoMapper;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;

namespace Services.Implementations
{
    public class TaskLabelService : EntityService<TaskLabel>, ITaskLabelService
    {
        public BaseResponse<TaskLabelOutputDto> Create(TaskLabelInputDto taskLabelInputDto)
        {
            var entity = Create(Mapper.Map<TaskLabel>(taskLabelInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException("Could not add task label");
            }

            return new SuccessResponse<TaskLabelOutputDto>(Mapper.Map<TaskLabelOutputDto>(entity));
        }

        public BaseResponse<IEnumerable<TaskLabelOutputDto>> Where(IDictionary<string, string> @params)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<TaskLabelOutputDto> Delete(Guid id)
        {
            var taskLabel = First(x => x.Id == id);
            var isSaved = DeletePermanent(taskLabel);
            if (!isSaved)
            {
                throw new InternalServerErrorException("Could not add task label");
            }

            return new SuccessResponse<TaskLabelOutputDto>(Mapper.Map<TaskLabelOutputDto>(taskLabel));
        }
    }
}
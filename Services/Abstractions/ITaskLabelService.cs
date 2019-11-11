using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface ITaskLabelService : IEntityService<TaskLabel>
    {
        BaseResponse<TaskLabelOutputDto> Create(TaskLabelInputDto taskLabelInputDto);
        BaseResponse<IEnumerable<TaskLabelOutputDto>> Where(IDictionary<string, string> @params);
        BaseResponse<TaskLabelOutputDto> Delete(Guid id);
    }
}
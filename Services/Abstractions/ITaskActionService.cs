using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface ITaskActionService : IEntityService<TaskAction>
    {
        BaseResponse<TaskActionOutputDto> Create(TaskActionInputDto taskAction);
        BaseResponse<IEnumerable<TaskActionOutputDto>> Where(IDictionary<string, string> predicate);
        BaseResponse<bool> Delete(Guid predicate);
    }
}
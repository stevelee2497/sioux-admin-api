using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface ITaskAssigneeService : IEntityService<TaskAssignee>
    {
        BaseResponse<TaskAssigneeOutputDto> Create(TaskAssigneeInputDto taskAssignee);
        BaseResponse<IEnumerable<TaskAssigneeOutputDto>> Where(IDictionary<string, string> predicate);
        BaseResponse<TaskAssigneeOutputDto> Delete(Guid id);
    }
}
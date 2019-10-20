using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface ITaskService : IEntityService<Task>
    {
        BaseResponse<TaskOutputDto> Create(TaskInputDto taskInputDto);
        BaseResponse<IEnumerable<TaskOutputDto>> Get(IDictionary<string, string> @params);
        BaseResponse<TaskOutputDto> Get(Guid @params);
        BaseResponse<bool> Update(TaskInputDto taskInputDto);
        BaseResponse<bool> Delete(Guid predicate);
    }
}
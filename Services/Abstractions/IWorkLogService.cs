using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface IWorkLogService : IEntityService<WorkLog>
    {
        BaseResponse<WorkLogOutputDto> Create(WorkLogInputDto workLogInputDto);
        BaseResponse<IEnumerable<WorkLogOutputDto>> Where(IDictionary<string, string> @params);
        BaseResponse<WorkLogOutputDto> Update(Guid logInputDto, WorkLogInputDto workLogInputDto);
        BaseResponse<WorkLogOutputDto> Delete(Guid id);
    }
}
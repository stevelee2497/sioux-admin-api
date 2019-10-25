using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface IPhaseService : IEntityService<Phase>
    {
        BaseResponse<PhaseOutputDto> Create(PhaseInputDto phaseInputDto);
        BaseResponse<IEnumerable<PhaseOutputDto>> Get(IDictionary<string, string> @params);
        BaseResponse<PhaseOutputDto> Get(Guid @params);
        BaseResponse<PhaseOutputDto> Update(PhaseInputDto phaseInputDto);
        BaseResponse<bool> Delete(Guid id);
    }
}
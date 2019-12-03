using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;

namespace Services.Abstractions
{
    public interface ILabelService : IEntityService<Label>
    {
        BaseResponse<LabelOutputDto> Create(LabelInputDto labelInputDto, Guid id);
        BaseResponse<IEnumerable<LabelOutputDto>> Get(IDictionary<string, string> @params);
        BaseResponse<LabelOutputDto> Get(Guid id);
        BaseResponse<bool> Update(Guid id, LabelInputDto labelInputDto);
        BaseResponse<bool> Delete(Guid id);
    }
}
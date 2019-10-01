using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface IPositionService : IEntityService<Position>
    {
        BaseResponse<PositionOutputDto> Create(PositionInputDto entity);
        BaseResponse<IEnumerable<PositionOutputDto>> CreateMany(List<PositionInputDto> objects);
        BaseResponse<PositionOutputDto> Get(Guid id);
        BaseResponse<IEnumerable<PositionOutputDto>> Where(IDictionary<string, string> predicate);
        BaseResponse<PositionOutputDto> Update(Guid entity, PositionInputDto skill);
        BaseResponse<bool> Delete(Guid id);
    }
}
using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface IUserPositionService : IEntityService<UserPosition>
    {
        BaseResponse<bool> Create(UserPositionInputDto userPosition);
        BaseResponse<int> CreateMany(List<UserPositionInputDto> userPositions);
        BaseResponse<bool> Delete(Guid predicate);
    }
}
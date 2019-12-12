using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface IBoardService : IEntityService<Board>
    {
        BaseResponse<BoardOutputDto> Create(BoardInputDto boardInputDto, Guid isSaved);
        BaseResponse<IEnumerable<BoardOutputDto>> Get(string role, IDictionary<string, string> @params);
        BaseResponse<BoardOutputDto> Get(Guid @params);
        BaseResponse<bool> Update(BoardInputDto boardInputDto);
        BaseResponse<bool> Delete(Guid predicate);
    }
}
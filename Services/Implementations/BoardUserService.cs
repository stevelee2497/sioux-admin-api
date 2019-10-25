using AutoMapper;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Implementations
{
    public class BoardUserService : EntityService<BoardUser>, IBoardUserService
    {
        public BaseResponse<bool> Create(BoardUserInputDto boardUserInputDto)
        {
            Create(Mapper.Map<BoardUser>(boardUserInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not add member to board");    
            }

            return new SuccessResponse<bool>(true);
        }
    }
}
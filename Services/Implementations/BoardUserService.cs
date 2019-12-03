using System;
using System.Linq;
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
        public BaseResponse<BoardUserOutputDto> Create(BoardUserInputDto boardUserInputDto)
        {
            var entity = Create(Mapper.Map<BoardUser>(boardUserInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not add member to board");    
            }

            var boardUser = Include(x => x.User).First(x => x.Id == entity.Id);
            return new SuccessResponse<BoardUserOutputDto>(Mapper.Map<BoardUserOutputDto>(boardUser));
        }

        public BaseResponse<bool> Delete(Guid id)
        {
            var boardUser = First(x => x.Id == id);
            var isDeleted = DeletePermanent(boardUser);
            return new SuccessResponse<bool>(isDeleted);
        }
    }
}
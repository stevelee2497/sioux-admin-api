using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Constants;
using DAL.Enums;
using DAL.Exceptions;
using DAL.Extensions;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;

namespace Services.Implementations
{
    public class BoardService : EntityService<Board>, IBoardService
    {
        private readonly IBoardUserService _boardUserService;

        public BoardService(IBoardUserService boardUserService)
        {
            _boardUserService = boardUserService;
        }

        #region C

        public BaseResponse<BoardOutputDto> Create(BoardInputDto boardInputDto, Guid userId)
        {
            var board = Create(Mapper.Map<Board>(boardInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, boardInputDto.Name));
            }

            var boardUser = new BoardUser {UserId = userId, BoardId = board.Id, MemberType = BoardMemberType.Admin};
            _boardUserService.Create(boardUser, out isSaved);
            if (!isSaved)
            {
                Delete(board);
                throw new InternalServerErrorException($"Could not add board role admin for user {userId}");
            }

            return new SuccessResponse<BoardOutputDto>(Mapper.Map<BoardOutputDto>(board));
        }

        #endregion

        #region R

        public BaseResponse<IEnumerable<BoardOutputDto>> Get(IDictionary<string, string> @params)
        {
            var boards = Where(@params).Select(x => Mapper.Map<BoardOutputDto>(x));

            return new SuccessResponse<IEnumerable<BoardOutputDto>>(boards);
        }

        public BaseResponse<BoardOutputDto> Get(Guid id)
        {
            var board = Include(x => x.BoardUsers).ThenInclude(x => x.User)
                .FirstOrDefault(x => x.IsActivated() && x.Id == id);

            return new SuccessResponse<BoardOutputDto>(Mapper.Map<BoardOutputDto>(board));
        }

        private IQueryable<Board> Where(IDictionary<string, string> @params)
        {
            var queries = @params.ToObject<BoardQuery>();

            if (!string.IsNullOrEmpty(queries.UserId))
            {
                var userId = Guid.Parse(queries.UserId);
                return _boardUserService.Include(x => x.Board)
                    .Where(x => x.IsActivated() && x.UserId == userId)
                    .Select(x => x.Board)
                    .Where(x => x.IsActivated());
            }

            return Where(x => x.IsActivated());
        }

        #endregion

        #region U

        public BaseResponse<bool> Update(BoardInputDto boardInputDto)
        {
            var isSaved = Update(Mapper.Map<Board>(boardInputDto));
            return new SuccessResponse<bool>(isSaved);
        }

        #endregion

        #region D

        public BaseResponse<bool> Delete(Guid id)
        {
            var board = FirstOrDefault(x => x.IsActivated() && x.Id == id);
            var isSaved = DeletePermanent(board);
            return new SuccessResponse<bool>(isSaved);
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Constants;
using DAL.Exceptions;
using DAL.Extensions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;

namespace Services.Implementations
{
    public class PositionService : EntityService<Position>, IPositionService
    {
        private readonly IUserPositionService _userPositionService;

        public PositionService(IUserPositionService userPositionService)
        {
            _userPositionService = userPositionService;
        }

        #region Create

        public BaseResponse<PositionOutputDto> Create(PositionInputDto positionInputDto)
        {
            var skill = Create(Mapper.Map<Position>(positionInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, positionInputDto.Name));
            }

            return new SuccessResponse<PositionOutputDto>(Mapper.Map<PositionOutputDto>(skill));
        }

        #endregion

        #region Create Many

        public BaseResponse<IEnumerable<PositionOutputDto>> CreateMany(List<PositionInputDto> positions)
        {
            var entities = CreateMany(positions.Select(Mapper.Map<Position>), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, "positions"));
            }

            return new SuccessResponse<IEnumerable<PositionOutputDto>>(entities.Select(Mapper.Map<PositionOutputDto>));
        }

        #endregion

        #region Get Specific


        public BaseResponse<PositionOutputDto> Get(Guid id)
        {
            var position = First(x => x.IsActivated() && x.Id == id);
            return new SuccessResponse<PositionOutputDto>(Mapper.Map<PositionOutputDto>(position));
        }

        #endregion

        #region Get Many

        public BaseResponse<IEnumerable<PositionOutputDto>> Where(IDictionary<string, string> queryObj)
        {
            var query = queryObj.ToObject<PositionQuery>();
            var skills = Where(query).Select(x => Mapper.Map<PositionOutputDto>(x));
            return new SuccessResponse<IEnumerable<PositionOutputDto>>(skills);
        }

        private IQueryable<Position> Where(PositionQuery query)
        {
            var linq = All();

            if (!string.IsNullOrEmpty(query.UserId))
            {
                var userId = Guid.Parse(query.UserId);
                linq = _userPositionService.Include(x => x.Position).Where(x => x.UserId == userId).Select(x => x.Position);
            }

            return linq;
        }

        #endregion

        #region Update

        public BaseResponse<PositionOutputDto> Update(Guid id, PositionInputDto positionInputDto)
        {
            var position = First(x => x.IsActivated() && x.Id == id);
            position.Name = positionInputDto.Name;
            var isSaved = Update(position);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, positionInputDto.Name));
            }

            return new SuccessResponse<PositionOutputDto>(Mapper.Map<PositionOutputDto>(position));
        }

        #endregion

        #region Delete

        public BaseResponse<bool> Delete(Guid id)
        {
            var position = First(x => x.IsActivated() && x.Id == id);
            var deleted = Delete(position);
            return new SuccessResponse<bool>(deleted);
        }

        #endregion
    }
}
using AutoMapper;
using DAL.Constants;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Enums;

namespace Services.Implementations
{
    public class PositionService : EntityService<Position>, IPositionService
    {
        #region Create

        public BaseResponse<PositionOutputDto> Create(PositionInputDto positionInputDto)
        {
            if (Contains(x => x.EntityStatus == EntityStatus.Activated && x.Name.Equals(positionInputDto.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new BadRequestException($"Position {positionInputDto.Name} is already existed");
            }

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
            var nonExistedEntities = positions.Select(x => x.Name).Except(Where(x => x.EntityStatus == EntityStatus.Activated).Select(x => x.Name)).Select(x => new Position { Name = x });
            var entities = CreateMany(nonExistedEntities, out var isSaved);
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
            var position = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            return new SuccessResponse<PositionOutputDto>(Mapper.Map<PositionOutputDto>(position));
        }

        #endregion

        #region Get Many

        public BaseResponse<IEnumerable<PositionOutputDto>> Where(IDictionary<string, string> queryObj)
        {
            var skills = Where(x => x.EntityStatus == EntityStatus.Activated).Select(x => Mapper.Map<PositionOutputDto>(x));
            return new SuccessResponse<IEnumerable<PositionOutputDto>>(skills);
        }

        #endregion

        #region Update

        public BaseResponse<PositionOutputDto> Update(Guid id, PositionInputDto positionInputDto)
        {
            var position = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
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
            var position = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var deleted = Delete(position);
            return new SuccessResponse<bool>(deleted);
        }

        #endregion
    }
}
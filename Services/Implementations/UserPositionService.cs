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

namespace Services.Implementations
{
    public class UserPositionService : EntityService<UserPosition>, IUserPositionService
    {
        #region Create

        public BaseResponse<bool> Create(UserPositionInputDto userPosition)
        {
            Create(Mapper.Map<UserPosition>(userPosition), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, $"user id {userPosition.UserId}\'s positions"));
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion

        #region Create Many

        public BaseResponse<int> CreateMany(List<UserPositionInputDto> userPositions)
        {
            var entities = CreateMany(userPositions.Select(Mapper.Map<UserPosition>), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, $"user positions"));
            }

            return new SuccessResponse<int>(entities.Count());
        }

        #endregion

        #region Delete

        public BaseResponse<bool> Delete(Guid id)
        {
            Delete(x => x.Id == id, out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, id));
            }

            return new SuccessResponse<bool>(true);
        }

        #endregion
    }
}
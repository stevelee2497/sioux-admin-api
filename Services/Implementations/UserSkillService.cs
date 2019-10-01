using AutoMapper;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Constants;
using DAL.Exceptions;

namespace Services.Implementations
{
    public class UserSkillService : EntityService<UserSkill>, IUserSkillService
    {
        #region Create

        public BaseResponse<bool> Create(UserSkillInputDto userSkill)
        {
            Create(Mapper.Map<UserSkill>(userSkill), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, $"user id {userSkill.UserId} skills"));
            }

            return new SuccessResponse<bool>(true); 
        }

        #endregion

        #region Create Many

        public BaseResponse<int> CreateMany(List<UserSkillInputDto> userSkill)
        {
            var entities = CreateMany(userSkill.Select(Mapper.Map<UserSkill>), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, $"user skills"));
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
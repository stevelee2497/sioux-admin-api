using System;
using AutoMapper;
using DAL.Enums;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Implementations
{
    public class UserRoleService : EntityService<UserRole>, IUserRoleService
    {
        public BaseResponse<bool> Create(UserRoleInputDto userRole)
        {
            var entity = Mapper.Map<UserRole>(userRole);
            if (Contains(x => x.EntityStatus == EntityStatus.Activated && x.UserId == entity.UserId && x.RoleId == entity.RoleId))
            {
                throw new BadRequestException($"User Id {entity.UserId} already has role {entity.RoleId}");
            }

            Create(entity, out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException($"Could not create role for user {userRole.UserId}");
            }

            return new SuccessResponse<bool>(true);
        }

        public BaseResponse<bool> Delete(Guid id)
        {
            Delete(x => x.EntityStatus == EntityStatus.Activated && x.Id == id, out var isSaved);
            if (!isSaved)
            {
                throw new BadRequestException($"Could not delete {id}");
            }

            return new SuccessResponse<bool>(true);
        }
    }
}
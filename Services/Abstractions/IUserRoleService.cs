using System;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
	public interface IUserRoleService : IEntityService<UserRole>
	{
        BaseResponse<bool> Create(UserRoleInputDto userRole);
        BaseResponse<bool> Delete(Guid id);
    }
}
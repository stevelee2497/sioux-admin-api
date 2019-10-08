using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Output;

namespace Services.Abstractions
{
	public interface IRoleService : IEntityService<Role>
	{
        BaseResponse<IEnumerable<RoleOutputDto>> GetAll();
    }
}
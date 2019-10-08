using AutoMapper;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Output;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations
{
    public class RoleService : EntityService<Role>, IRoleService
	{
        public BaseResponse<IEnumerable<RoleOutputDto>> GetAll()
        {
            var roles = All().Select(x => Mapper.Map<RoleOutputDto>(x));
            return new SuccessResponse<IEnumerable<RoleOutputDto>>(roles);
        }
    }
}
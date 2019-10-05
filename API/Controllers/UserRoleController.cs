using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;

namespace API.Controllers
{
    [Route("api/userRoles")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Create([FromBody] UserRoleInputDto userRole)
        {
            return _userRoleService.Create(userRole);
        }


        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _userRoleService.Delete(id);
        }
    }
}
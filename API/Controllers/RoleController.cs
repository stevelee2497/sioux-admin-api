using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Output;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<RoleOutputDto>> All()
        {
            return _roleService.GetAll();
        }
    }
}
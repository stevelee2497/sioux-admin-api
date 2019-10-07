using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
    [Route("api/userSkills")]
    public class UserSkillController : Controller
    {
        private readonly IUserSkillService _userSkillService;

        public UserSkillController(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Create([FromBody] UserSkillInputDto userSkill)
        {
            return _userSkillService.Create(userSkill);
        }

        [HttpPost("many")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<int> CreateMany([FromBody] List<UserSkillInputDto> userSkill)
        {
            return _userSkillService.CreateMany(userSkill);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _userSkillService.Delete(id);
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<UserSkillOutputDto>> Where([FromHeader] IDictionary<string, string> @params)
        {
            return _userSkillService.Where(@params);
        }
    }
}
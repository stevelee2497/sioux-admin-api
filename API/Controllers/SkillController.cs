using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/skills")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<SkillOutputDto> Create([FromBody] SkillInputDto skill)
        {
            return _skillService.Create(skill);
        }

        [HttpPost("many")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<SkillOutputDto>> CreateMany([FromBody] List<SkillInputDto> skills)
        {
            return _skillService.CreateMany(skills);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public BaseResponse<SkillOutputDto> Get(Guid id)
        {
            return _skillService.Get(id);
        }

        [HttpGet]
        [Produces("application/json")]
        public BaseResponse<IEnumerable<SkillOutputDto>> Where([FromHeader] IDictionary<string, string> @params)
        {
            return _skillService.Where(@params);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<SkillOutputDto> Update(Guid id, [FromBody] SkillInputDto skill)
        {
            return _skillService.Update(id, skill);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        public BaseResponse<bool> Delete(Guid id)
        {
            return _skillService.Delete(id);
        }
    }
}
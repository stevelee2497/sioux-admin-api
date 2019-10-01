using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface ISkillService : IEntityService<Skill>
    {
        BaseResponse<SkillOutputDto> Create(SkillInputDto skillInputDto);
        BaseResponse<IEnumerable<SkillOutputDto>> CreateMany(List<SkillInputDto> objects);
        BaseResponse<SkillOutputDto> Get(Guid id);
        BaseResponse<IEnumerable<SkillOutputDto>> Where(IDictionary<string, string> query);
        BaseResponse<SkillOutputDto> Update(Guid id, SkillInputDto skill);
        BaseResponse<bool> Delete(Guid predicate);
    }
}
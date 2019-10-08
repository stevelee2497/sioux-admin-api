using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
    public interface IUserSkillService : IEntityService<UserSkill>
    {
        BaseResponse<bool> Create(UserSkillInputDto userSkill);
        BaseResponse<int> CreateMany(List<UserSkillInputDto> userSkill);
        BaseResponse<bool> Delete(Guid predicate);
        BaseResponse<IEnumerable<UserSkillOutputDto>> Where(IDictionary<string, string> predicate);
    }
}
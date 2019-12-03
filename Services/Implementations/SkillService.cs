using AutoMapper;
using DAL.Constants;
using DAL.Exceptions;
using DAL.Models;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Enums;

namespace Services.Implementations
{
    public class SkillService : EntityService<Skill>, ISkillService
    {
        private readonly IUserSkillService _userSkillService;

        public SkillService(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
        }

        #region Create

        public BaseResponse<SkillOutputDto> Create(SkillInputDto skillInputDto)
        {
            if (Contains(x => x.EntityStatus == EntityStatus.Activated && x.Name.Equals(skillInputDto.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new BadRequestException($"Skill {skillInputDto.Name} is already existed");
            }
            var skill = Create(Mapper.Map<Skill>(skillInputDto), out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, skillInputDto.Name));
            }

            return new SuccessResponse<SkillOutputDto>(Mapper.Map<SkillOutputDto>(skill));
        }

        #endregion

        #region Create Many

        public BaseResponse<IEnumerable<SkillOutputDto>> CreateMany(List<SkillInputDto> skills)
        {
            var nonExistedSkills = skills.Select(x => x.Name).Except(Where(x => x.EntityStatus == EntityStatus.Activated).Select(x => x.Name)).Select(x => new Skill {Name = x});
            var entities = CreateMany(nonExistedSkills, out var isSaved);

            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, "skills"));
            }

            return new SuccessResponse<IEnumerable<SkillOutputDto>>(entities.Select(Mapper.Map<SkillOutputDto>));
        }

        #endregion

        #region Get Specific


        public BaseResponse<SkillOutputDto> Get(Guid id)
        {
            var skill = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            return new SuccessResponse<SkillOutputDto>(Mapper.Map<SkillOutputDto>(skill));
        }

        #endregion

        #region Get Many

        public BaseResponse<IEnumerable<SkillOutputDto>> Where(IDictionary<string, string> queryObj)
        {
            var query = queryObj.ToObject<SkillQuery>();
            var skills = Where(query).Select(x => Mapper.Map<SkillOutputDto>(x));
            return new SuccessResponse<IEnumerable<SkillOutputDto>>(skills);
        }

        private IQueryable<Skill> Where(SkillQuery query)
        {
            var linq = Where(x => x.EntityStatus == EntityStatus.Activated);

            if (!string.IsNullOrEmpty(query.UserId))
            {
                var userId = Guid.Parse(query.UserId);
                linq = _userSkillService.Include(x => x.Skill).Where(x => x.UserId == userId && x.EntityStatus == EntityStatus.Activated).Select(x => x.Skill);
            }

            return linq;
        }

        #endregion

        #region Update

        public BaseResponse<SkillOutputDto> Update(Guid id, SkillInputDto skillInputDto)
        {
            var skill = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            skill.Name = skillInputDto.Name;
            var isSaved = Update(skill);
            if (!isSaved)
            {
                throw new InternalServerErrorException(string.Format(Error.CreateError, skillInputDto.Name));
            }

            return new SuccessResponse<SkillOutputDto>(Mapper.Map<SkillOutputDto>(skill));
        }

        #endregion

        #region Delete

        public BaseResponse<bool> Delete(Guid id)
        {
            var skill = First(x => x.EntityStatus == EntityStatus.Activated && x.Id == id);
            var deleted = Delete(skill);
            return new SuccessResponse<bool>(deleted);
        }

        #endregion
    }
}
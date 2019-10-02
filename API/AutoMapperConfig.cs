using AutoMapper;
using AutoMapper.Configuration;
using DAL.Extensions;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API
{
    public static class AutoMapperConfig
	{
		public static void RegisterModel()
		{
			var configuration = new MapperConfigurationExpression();

			#region User

			configuration.CreateMap<UserInputDto, User>();

            configuration.CreateMap<User, UserOutputDto>()
                .ForMember(
                    destination => destination.Roles,
                    map => map.MapFrom(source => source.GetRoles())
                )
                .ForMember(
                    destination => destination.Gender,
                    map => map.MapFrom(source => source.Gender.ToString())
                );

            #endregion

            #region Skill

            configuration.CreateMap<SkillInputDto, Skill>();

            configuration.CreateMap<Skill, SkillOutputDto>();

            #endregion


            #region User Skills

            configuration.CreateMap<UserSkillInputDto, UserSkill>();

            configuration.CreateMap<UserSkill, UserSkillOutputDto>();

            #endregion

            Mapper.Initialize(configuration);
		}
	}
}
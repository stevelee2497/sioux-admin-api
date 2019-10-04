using System;
using System.Globalization;
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


            #region UserSkill

            configuration.CreateMap<UserSkillInputDto, UserSkill>();

            configuration.CreateMap<UserSkill, UserSkillOutputDto>().ForMember(
                destination => destination.Skill,
                map => map.MapFrom(source => source.Skill.Name)
            );

            #endregion

            #region Position

            configuration.CreateMap<PositionInputDto, Position>();

            configuration.CreateMap<Position, PositionOutputDto>();

            #endregion

            #region UserPosition

            configuration.CreateMap<UserPositionInputDto, UserPosition>();

            configuration.CreateMap<UserPosition, UserPositionOutputDto>().ForMember(
                destination => destination.Position,
                map => map.MapFrom(source => source.Position.Name)
            );

            #endregion

            Mapper.Initialize(configuration);
		}
	}
}
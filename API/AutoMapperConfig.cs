﻿using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration;
using DAL.Models;
using Newtonsoft.Json;
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
                    destination => destination.Gender,
                    map => map.MapFrom(source => source.Gender.ToString())
                )
                .ForMember(
                    destination => destination.Roles,
                    map => map.MapFrom(source => source.UserRoles)
                )
                .ForMember(
                    destination => destination.Skills,
                    map => map.MapFrom(source => source.UserSkills)
                );

            #endregion

            #region UserRole

            configuration.CreateMap<UserRoleInputDto, UserRole>();

            configuration.CreateMap<UserRole, UserRoleOutputDto>()
                .ForMember(
                    destination => destination.RoleName,
                    map => map.MapFrom(source => source.Role.Name)
                );


            #endregion

            #region Role

            configuration.CreateMap<Role, RoleOutputDto>();

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

            #region TimeLineEvent

            configuration.CreateMap<TimeLineEventInputDto, TimeLineEvent>();

            configuration.CreateMap<TimeLineEvent, TimeLineEventOutputDto>();

            #endregion

            #region Board

            configuration.CreateMap<BoardInputDto, Board>()
                .ForMember(
                    destination => destination.PhaseOrder,
                    map => map.MapFrom(source => JsonConvert.SerializeObject(source.PhaseOrder))
                );

            configuration.CreateMap<Board, BoardOutputDto>()
                .ForMember(
                    destination => destination.PhaseOrder,
                    map => map.MapFrom(source => JsonConvert.DeserializeObject<IEnumerable<string>>(source.PhaseOrder))
                )
                .ForMember(
                    destination => destination.Users,
                    map => map.MapFrom(source => source.BoardUsers)
                );

            #endregion

            #region BoardUser

            configuration.CreateMap<BoardUser, BoardUserOutputDto>()
                .ForMember(
                    destination => destination.FullName,
                    map => map.MapFrom(source => source.User.FullName)
                )
                .ForMember(
                    destination => destination.AvatarUrl,
                    map => map.MapFrom(source => source.User.AvatarUrl)
                );

            #endregion

            Mapper.Initialize(configuration);
		}
	}
}
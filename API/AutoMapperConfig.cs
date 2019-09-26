using System;
using AutoMapper;
using AutoMapper.Configuration;
using DAL.Enums;
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

			configuration.CreateMap<AuthDto, User>().ForMember(
                destination => destination.Gender,
                map => map.MapFrom(source => Enum.Parse<Gender>(source.Gender, true))
            );

			configuration.CreateMap<UserInputDto, User>();

			configuration.CreateMap<User, UserOutputDto>().ForMember(
				destination => destination.Roles,
				map => map.MapFrom(source => source.GetRoles())
			);

			#endregion

			Mapper.Initialize(configuration);
		}
	}
}
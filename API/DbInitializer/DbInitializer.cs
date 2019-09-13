using DAL.Constants;
using DAL.Exceptions;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;
using System;
using System.Linq;
using DAL.Extensions;

namespace API.DbInitializer
{
	internal static class DbInitializer
	{
		public static void Seed(IServiceProvider services)
		{
			SeedRoles(services);
		}

		private static void SeedRoles(IServiceProvider services)
		{
			var service = services.GetService<IRoleService>();
			if (service.Count() > 0)
			{
				return;
			}

			var defaultRoles = typeof(DefaultRole).GetConstantValues<string>().Select(role => new Role {Name = role});

			service.CreateMany(defaultRoles, out var isSaved);
			if (!isSaved)
			{
				throw new InternalServerErrorException("Couldn't create default roles");
			}
		}
	}
}
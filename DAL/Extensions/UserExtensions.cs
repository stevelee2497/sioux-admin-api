using System.Linq;
using DAL.Models;

namespace DAL.Extensions
{
	public static class UserExtensions
	{
		public static string[] GetRoles(this User user) => user.UserRoles.Where(ur => ur.IsActivated())
			.Select(ur => ur.Role.Name)
			.ToArray();
	}
}
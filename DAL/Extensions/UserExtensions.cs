using System.Linq;
using DAL.Helpers;
using DAL.Models;

namespace DAL.Extensions
{
	public static class UserExtensions
	{
		public static string[] GetRoles(this User user) => user.UserRoles.Where(ur => ur.IsActivated())
			.Select(ur => ur.Role.Name)
			.ToArray();

        public static User EncodePassword(this User user, string password)
        {
            var (salt, hash) = PasswordHelper.GenerateSecurePassword(password);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            return user;
        }
	}
}
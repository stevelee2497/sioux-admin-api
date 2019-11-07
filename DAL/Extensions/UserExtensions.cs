using System.Collections.Generic;
using System.Linq;
using DAL.Enums;
using DAL.Helpers;
using DAL.Models;

namespace DAL.Extensions
{
	public static class UserExtensions
	{
		public static IEnumerable<string> GetRoles(this User user) => user.UserRoles?.Where(ur => ur.EntityStatus == EntityStatus.Activated).Select(ur => ur.Role.Name);

        public static User EncodePassword(this User user, string password)
        {
            var (salt, hash) = PasswordHelper.GenerateSecurePassword(password);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            return user;
        }
	}
}
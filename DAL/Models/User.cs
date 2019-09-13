using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
	[Table("User")]
	public class User : BaseEntity
	{
		[Required]
		public string Email { get; set; }

		[Required]
		public byte[] PasswordSalt { get; set; }

		[Required]
		public byte[] PasswordHash { get; set; }

		[Required]
		public string DisplayName { get; set; }

		public string AvatarUrl { get; set; }

		public DateTimeOffset? AllowTokensSince { get; set; }

		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
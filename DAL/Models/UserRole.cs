﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
	[Table("UserRole")]
	public class UserRole : BaseEntity
	{
		public Guid UserId { get; set; }

		public Guid RoleId { get; set; }

		public virtual User User { get; set; }

		public virtual Role Role { get; set; }
	}
}
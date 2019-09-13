using DAL.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public interface IEntity
	{
	}

	public abstract class BaseEntity : IEntity
	{
		[Key]
		public Guid Id { get; set; }

		[DefaultValue(EntityStatus.Activated)]
		public EntityStatus EntityStatus { get; set; }

		[Required]
		public DateTimeOffset CreatedTime { get; set; }

		[Required]
		public DateTimeOffset UpdatedTime { get; set; }
	}
}
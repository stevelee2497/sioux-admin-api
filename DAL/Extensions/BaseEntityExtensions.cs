using DAL.Enums;
using DAL.Models;

namespace DAL.Extensions
{
	public static class BaseEntityExtensions
	{
		public static bool IsActivated(this BaseEntity entity) => entity.EntityStatus == EntityStatus.Activated;
	}
}
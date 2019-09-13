using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DAL.Models
{
	[Table("Role")]
	[DataContract]
	public class Role : BaseEntity
	{
		[Required]
		[DataMember(Name = "name")]
		public string Name { get; set; }

		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
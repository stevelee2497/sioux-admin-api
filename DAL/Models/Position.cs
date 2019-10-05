using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Position")]
    public class Position: BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

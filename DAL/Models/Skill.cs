using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Skill")]
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("UserSkill")]
    public class UserSkill : BaseEntity
    {
        public Guid UserId { get; set; }
        
        public Guid SkillId { get; set; }

        public virtual User User { get; set; }

        public virtual Skill Skill { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("BoardUser")]
    public class BoardUser : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid BoardId { get; set; }

        public virtual User User { get; set; }

        public virtual Board Board { get; set; }
    }
}
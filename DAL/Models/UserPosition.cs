using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("UserPosition")]
    public class UserPosition : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid PositionId { get; set; }

        public virtual User User { get; set; }

        public virtual Position Position { get; set; }
    }
}

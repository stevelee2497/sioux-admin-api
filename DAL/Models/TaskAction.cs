using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("UserAction")]
    public class TaskAction : BaseEntity
    {
        public string ActionDescription { get; set; }

        public Guid UserId { get; set; }

        public Guid TaskId { get; set; }

        public virtual User User { get; set; }

        public virtual Task Task { get; set; }
    }
}
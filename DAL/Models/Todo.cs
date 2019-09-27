using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Todo")]
    public class Todo : BaseEntity
    {
        public string Content { get; set; }

        public bool Finished { get; set; }

        public Guid TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}

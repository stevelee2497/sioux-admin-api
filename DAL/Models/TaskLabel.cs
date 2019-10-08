using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("TaskLabel")]
    public class TaskLabel : BaseEntity
    {
        public Guid LabelId { get; set; }

        public Guid TaskId { get; set; }

        public virtual Label Label { get; set; }
        
        public virtual Task Task { get; set; }
    }
}

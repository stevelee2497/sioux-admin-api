using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("WorkLog")]
    public class WorkLog : BaseEntity
    {
        public TimeSpan Amount { get; set; }

        public DateTimeOffset DateLog { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }

        public Guid TaskId { get; set; }

        public virtual User User { get; set; }

        public virtual Task Task { get; set; }
    }
}
using DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Attachment")]
    public class Attachment : BaseEntity
    {
        public string Url { get; set; }

        public MediaType MediaType { get; set; }

        public Guid TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}

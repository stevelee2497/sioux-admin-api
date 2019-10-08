using System;

namespace DAL.Models
{
    public class TimeLineEvent : BaseEntity
    {
        public string Event { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
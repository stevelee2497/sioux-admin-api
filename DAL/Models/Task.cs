﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Task")]
    public class Task : BaseEntity
    {
        public long TaskKey { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public TimeSpan Estimation { get; set; }

        public TimeSpan SpentTime { get; set; }

        public Guid ReporterUserId { get; set; }

        public Guid BoardId { get; set; }   

        public virtual User Reporter { get; set; }

        public virtual Board Board { get; set; }

        public virtual ICollection<WorkLog> WorkLogs { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<TaskAssignee> TaskAssignees { get; set; }

        public virtual ICollection<TaskAction> TaskActions { get; set; }

        public virtual ICollection<TaskLabel> TaskLabels { get; set; }
    }
}

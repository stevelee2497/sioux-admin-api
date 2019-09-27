﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Task")]
    public class Task : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public TimeSpan Estimation { get; set; }

        public Guid ReporterUserId { get; set; }

        public virtual User Reporter { get; set; }

        public virtual ICollection<WorkLog> WorkLogs { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<TaskAssignee> TaskAssignees { get; set; }

        public virtual ICollection<TaskAction> TaskActions { get; set; }
    }
}
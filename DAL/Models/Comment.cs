﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Comment")]
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public Guid UserId { get; set; }

        public Guid TaskId { get; set; }

        public virtual User User { get; set; }

        public virtual Task Task { get; set; }
    }
}
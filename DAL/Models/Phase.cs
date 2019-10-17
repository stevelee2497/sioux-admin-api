﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Phase")]
    public class Phase : BaseEntity
    {
        public string Name { get; set; }

        public Guid BoardId { get; set; }

        public string TaskOrder { get; set; }
     
        public virtual Board Board { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
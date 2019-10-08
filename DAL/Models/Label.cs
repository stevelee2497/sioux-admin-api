using System.Collections.Generic;

namespace DAL.Models
{
    public class Label : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<TaskLabel> TaskLabels { get; set; }
    }
}

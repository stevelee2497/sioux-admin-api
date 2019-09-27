using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Board")]
    public class Board : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<BoardUser> BoardUsers { get; set; }

        public virtual ICollection<Phase> Phases { get; set; }
    }
}

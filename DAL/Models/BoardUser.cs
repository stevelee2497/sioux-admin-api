using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Enums;

namespace DAL.Models
{
    [Table("BoardUser")]
    public class BoardUser : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid BoardId { get; set; }

        [DefaultValue(BoardMemberType.Member)]
        public BoardMemberType MemberType { get; set; }

        public virtual User User { get; set; }

        public virtual Board Board { get; set; }
    }
}
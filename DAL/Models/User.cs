using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Enums;

namespace DAL.Models
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        public string AvatarUrl { get; set; }

        public string FullName { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string SocialLink { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? AllowTokensSince { get; set; }

        [InverseProperty("Reporter")]
        public virtual ICollection<Task> CreatedTasks { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserPosition> UserPositions { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }

        public virtual ICollection<WorkLog> WorkLogs { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<TaskAssignee> TaskAssignees { get; set; }

        public virtual ICollection<TaskAction> TaskActions { get; set; }

        public virtual ICollection<TimeLineEvent> TimeLineEvents { get; set; }

    }
}
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
        public string Email { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        public string AvatarUrl { get; set; }

        public string FullName { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string SocialLink { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string Description { get; set; }

        public string Timeline { get; set; }

        public DateTimeOffset? AllowTokensSince { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
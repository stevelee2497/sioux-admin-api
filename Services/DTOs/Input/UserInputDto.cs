using System;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class UserInputDto
	{
        public string UserName { get; set; }

		public string AvatarUrl { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PositionId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public string SocialLink { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }
	}
}
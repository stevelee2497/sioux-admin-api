using System;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class UserInputDto
	{
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string DisplayName { get; set; }

		public string AvatarUrl { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string SocialLink { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }

        public string Timeline { get; set; }
	}
}
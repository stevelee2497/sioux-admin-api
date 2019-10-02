using System;

namespace Services.DTOs.Output
{
	public class UserOutputDto
	{
		public string Id { get; set; }

		public string UserName { get; set; }

		public string AvatarUrl { get; set; }

        public string FullName { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string SocialLink { get; set; }

        public string Gender { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string Description { get; set; }

		public string[] Roles { get; set; }
	}
}
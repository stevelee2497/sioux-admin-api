using System.Collections.Generic;

namespace Services.DTOs.Output
{
    public class UserOutputDto
	{
		public string Id { get; set; }

		public string UserName { get; set; }

		public string AvatarUrl { get; set; }

        public string FullName { get; set; }

        public PositionOutputDto Position { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string SocialLink { get; set; }

        public string Gender { get; set; }

        public string BirthDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<UserSkillOutputDto> Skills { get; set; }

        public IEnumerable<UserRoleOutputDto> Roles { get; set; }
	}
}
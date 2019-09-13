namespace Services.DTOs.Input
{
	public class UserInputDto
	{
		public string Email { get; set; }

		public string DisplayName { get; set; }

		public string AvatarUrl { get; set; }

		public string[] Roles { get; set; }
	}
}
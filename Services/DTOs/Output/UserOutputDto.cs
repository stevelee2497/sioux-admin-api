namespace Services.DTOs.Output
{
	public class UserOutputDto
	{
		public string Id { get; set; }

		public string Email { get; set; }

		public string DisplayName { get; set; }

		public string AvatarUrl { get; set; }

		public string[] Roles { get; set; }
	}
}
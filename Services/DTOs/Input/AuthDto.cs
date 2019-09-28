using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class AuthDto
	{
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
    }
}
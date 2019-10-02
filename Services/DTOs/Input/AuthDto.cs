using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class AuthDto
	{
		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }
    }
}
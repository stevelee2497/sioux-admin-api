using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Services.DTOs.Input
{
	[DataContract]
	public class AuthDto
	{
		[DataMember(Name = "email")]
		[Required(ErrorMessage = "Vui lòng nhập tên tài khoản.")]
		public string Email { get; set; }

		[DataMember(Name = "password")]
		[Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
		public string Password { get; set; }
	}
}
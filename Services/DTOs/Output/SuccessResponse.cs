using System.Net;

namespace Services.DTOs.Output
{
	public class SuccessResponse<T> : BaseResponse<T>
	{
		public SuccessResponse(T data = default) : base(HttpStatusCode.OK, data: data)
		{
		}
	}
}
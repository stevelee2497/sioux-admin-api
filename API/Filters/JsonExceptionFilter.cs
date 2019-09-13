using System.Net;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.DTOs.Output;

namespace API.Filters
{
	public class JsonExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			HttpStatusCode statusCode;
			switch (context.Exception)
			{
				case BadRequestException _:
					statusCode = HttpStatusCode.BadRequest;
					break;
				case ConflictException _:
					statusCode = HttpStatusCode.Conflict;
					break;
				case DataNotFoundException _:
					statusCode = HttpStatusCode.NotFound;
					break;
				case InternalServerErrorException _:
					statusCode = HttpStatusCode.InternalServerError;
					break;
				default:
					statusCode = HttpStatusCode.ServiceUnavailable;
					break;
			}

			var result = new ObjectResult(new BaseResponse<bool>(statusCode, context.Exception.Message)) { StatusCode = (int)statusCode };
			context.Result = result;
		}
	}
}
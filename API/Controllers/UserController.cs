using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace API.Controllers
{
	[Route("api/users")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		[Authorize]
		[Produces("application/json")]
		public BaseResponse<List<UserOutputDto>> All([FromHeader] IDictionary<string, string> @params)
		{
			return _userService.All(@params);
		}

		[HttpPost("register")]
		[Produces("application/json")]
		public BaseResponse<string> Register([FromBody] AuthDto user)
		{
			return _userService.Register(user);
		}

		[HttpPost("login")]
		[Produces("application/json")]
		public BaseResponse<Token> Login([FromBody] AuthDto user)
		{
			return _userService.Login(user);
		}

		[HttpPut("{id}")]
		[Authorize]
		[Produces("application/json")]
		public BaseResponse<UserOutputDto> Update(Guid id, [FromBody] UserInputDto userInput)
		{
			return _userService.Update(id, userInput);
		}
	}
}
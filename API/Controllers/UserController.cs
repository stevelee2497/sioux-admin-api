using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using System;
using System.Collections.Generic;

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
		[Produces("application/json")]
		public BaseResponse<IEnumerable<UserOutputDto>> All([FromHeader] IDictionary<string, string> @params)
		{
			return _userService.All(@params);
		}

        [HttpGet("{id}")]
        [Produces("application/json")]
        public BaseResponse<UserOutputDto> Get(Guid id)
        {
            return _userService.Get(id);
        }

        [HttpPost]
		[Produces("application/json")]
		public BaseResponse<string> Register([FromBody] UserInputDto user)
		{
			return _userService.Register(user);
		}

		[HttpPost("login")]
		[Produces("application/json")]
		public BaseResponse<Passport> Login([FromBody] AuthDto user)
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
using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
	public interface IUserService : IEntityService<User>
	{
		BaseResponse<List<UserOutputDto>> All(IDictionary<string, string> @params);
		BaseResponse<User> Get(Guid id);
		BaseResponse<string> Register(AuthDto user);
		BaseResponse<Token> Login(AuthDto user);
		BaseResponse<UserOutputDto> Update(Guid userId, UserInputDto userInput);
	}
}
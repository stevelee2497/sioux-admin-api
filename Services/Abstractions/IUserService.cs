using System;
using System.Collections.Generic;
using DAL.Models;
using Services.DTOs.Input;
using Services.DTOs.Output;

namespace Services.Abstractions
{
	public interface IUserService : IEntityService<User>
	{
		BaseResponse<IEnumerable<UserOutputDto>> All(IDictionary<string, string> @params);
		BaseResponse<UserOutputDto> Get(Guid id);
		BaseResponse<string> Register(UserInputDto user);
		BaseResponse<Passport> Login(AuthDto user);
		BaseResponse<UserOutputDto> Update(Guid userId, UserInputDto userInput);
    }
}
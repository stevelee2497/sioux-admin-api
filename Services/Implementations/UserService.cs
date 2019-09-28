using AutoMapper;
using DAL.Constants;
using DAL.Exceptions;
using DAL.Extensions;
using DAL.Helpers;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Services.Abstractions;
using Services.DTOs.Input;
using Services.DTOs.Output;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Services.Implementations
{
	public class UserService : EntityService<User>, IUserService
	{
		private readonly IRoleService _roleService;
		private readonly IUserRoleService _userRoleService;

		public UserService(IUserRoleService userRoleService, IRoleService roleService)
		{
			_userRoleService = userRoleService;
			_roleService = roleService;
		}

        #region Get Users

        public BaseResponse<List<UserOutputDto>> All(IDictionary<string, string> @params)
        {
            var users = Include(user => user.UserRoles).ThenInclude(user => user.Role)
                .AsEnumerable()
                .Select(Mapper.Map<UserOutputDto>)
                .ToList();

            return new BaseResponse<List<UserOutputDto>>(HttpStatusCode.OK, data: users);
        }

        #endregion

        #region Get Specific User

        public BaseResponse<User> Get(Guid id)
        {
            var user = Find(id);
            if (user == null)
            {
                throw new DataNotFoundException("userOutput");
            }

            return new BaseResponse<User>(HttpStatusCode.OK, data: user);
        }

        #endregion

        #region Register a user

        public BaseResponse<string> Register(UserInputDto authDto)
        {
            CheckIfEmailExisted(authDto.Email);
            var user = CreateUser(authDto);
            SetRoleForUser(user.Id, DefaultRole.User);
            return new BaseResponse<string>(HttpStatusCode.OK, data: "Đăng ký thành công");
        }

        private void CheckIfEmailExisted(string email)
        {
            if (FirstOrDefault(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)) != null)
            {
                throw new BadRequestException("Tài khoản đã tồn tại.");
            }
        }

        private User CreateUser(UserInputDto authDto)
        {
            var user = Mapper.Map<User>(authDto).EncodePassword(authDto.Password);
            var createdUser = Create(user, out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException("Không thể đăng ký, vui lòng thử lại");
            }

            return createdUser;
        }

        #endregion

        #region Login

        public BaseResponse<Token> Login(AuthDto authDto)
        {
            var user = First(u => u.IsActivated() && u.Email.Equals(authDto.Email, StringComparison.InvariantCultureIgnoreCase));
            CheckUserPassword(authDto.Password, user);
            var token = JwtHelper.CreateToken(Mapper.Map<UserOutputDto>(user));
            return new BaseResponse<Token>(HttpStatusCode.OK, data: token);
        }

        private static void CheckUserPassword(string password, User user)
        {
            var hash = PasswordHelper.ComputeHash(password, user.PasswordSalt);
            if (!user.PasswordHash.SequenceEqual(hash))
            {
                throw new BadRequestException("Mật khẩu không chính xác.");
            }
        }

        #endregion

        #region Update

        public BaseResponse<UserOutputDto> Update(Guid userId, UserInputDto userInput)
        {
            var newUser = Mapper.Map<User>(userInput);
            var oldUser = Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefault(u => u.Id == userId);
            oldUser = UpdateUserInformationIfChanged(oldUser, newUser);
            oldUser = UpdateUserRoleIfChanged(oldUser, oldUser.GetRoles(), userInput.Roles);
            return new BaseResponse<UserOutputDto>(statusCode: HttpStatusCode.OK,
                data: Mapper.Map<UserOutputDto>(oldUser));
        }

        private User UpdateUserInformationIfChanged(User oldUser, User newUser)
        {
            if (oldUser == null)
            {
                throw new BadRequestException("Không tồn tại tài khoản này");
            }

            var updateUserResult = Update(oldUser);
            if (!updateUserResult)
            {
                throw new InternalServerErrorException(
                    $"Không thể update cho userOutput {JsonConvert.SerializeObject(newUser)}");
            }

            return oldUser;
        }

        private User UpdateUserRoleIfChanged(User user, string[] oldRoles, string[] newRoles)
        {
            // update userOutput's role to admin
            if (newRoles.Contains(DefaultRole.Admin) && !oldRoles.Contains(DefaultRole.Admin))
            {
                var adminRole = _roleService.FirstOrDefault(r => r.Name.Equals(DefaultRole.Admin));
                var adminUserRole =
                    _userRoleService.Create(new UserRole { UserId = user.Id, RoleId = adminRole.Id }, out var isSaved);
                if (!isSaved)
                {
                    throw new InternalServerErrorException(
                        $"Không thể update role cho userOutput {JsonConvert.SerializeObject(user)}");
                }

                adminUserRole.Role = adminRole;
                user.UserRoles.Add(adminUserRole);
            }

            // set userOutput's role from admin to userOutput
            if (!newRoles.Contains(DefaultRole.Admin) && oldRoles.Contains(DefaultRole.Admin))
            {
                var adminUserRole = user.UserRoles.First(ur => ur.IsActivated() && ur.Role.Name.Equals(DefaultRole.Admin));
                var isDeleted = _userRoleService.Delete(adminUserRole);
                if (!isDeleted)
                {
                    throw new InternalServerErrorException(
                        $"Không thể update role cho userOutput {JsonConvert.SerializeObject(user)}");
                }

                user.UserRoles.Remove(adminUserRole);
            }

            return user;
        }

        #endregion

        #region Common

        private void SetRoleForUser(Guid userId, string roleName)
        {
            var role = _roleService.FirstOrDefault(r => r.Name.Equals(roleName));
            if (role == null)
            {
                throw new InternalServerErrorException($"Không có role {roleName} tồn tại");
            }

            _userRoleService.Create(new UserRole { UserId = userId, RoleId = role.Id }, out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException("Không thể đăng ký, vui lòng thử lại");
            }
        }

        #endregion
    }
}
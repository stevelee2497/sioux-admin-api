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
            var user = Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .Include(x => x.UserPositions).ThenInclude(x => x.Position)
                .Include(x => x.UserSkills).ThenInclude(x => x.Skill)
                .First(x => x.Id == id);

            return new BaseResponse<User>(HttpStatusCode.OK, data: user);
        }

        #endregion

        #region Register a user

        public BaseResponse<string> Register(UserInputDto authDto)
        {
            CheckIfAccountExisted(authDto.Email);
            var user = CreateUser(authDto);
            SetRoleForUser(user.Id, DefaultRole.User);
            return new BaseResponse<string>(HttpStatusCode.OK, data: "Registered successfully");
        }

        private void CheckIfAccountExisted(string userName)
        {
            if (FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase)) != null)
            {
                throw new BadRequestException($"Account with user name {userName} is already existed");
            }
        }

        private User CreateUser(UserInputDto authDto)
        {
            var user = Mapper.Map<User>(authDto).EncodePassword(authDto.UserName);
            user.UserName = authDto.Email;
            var createdUser = Create(user, out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException($"Could not create user {authDto.UserName}");
            }

            return createdUser;
        }

        #endregion

        #region Login

        public BaseResponse<Token> Login(AuthDto authDto)
        {
            var user = Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .Include(x => x.UserPositions).ThenInclude(x => x.Position)
                .Include(x => x.UserSkills).ThenInclude(x => x.Skill)
                .First(u => u.IsActivated() && u.UserName.Equals(authDto.UserName, StringComparison.InvariantCultureIgnoreCase));
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
            var oldUser = First(u => u.Id == userId);
            oldUser = UpdateUserInformationIfChanged(oldUser, newUser);
            return new SuccessResponse<UserOutputDto>(Mapper.Map<UserOutputDto>(oldUser));
        }

        private User UpdateUserInformationIfChanged(User oldUser, User newUser)
        {
            oldUser.AvatarUrl = newUser.AvatarUrl;
            oldUser.FullName = newUser.FullName;
            oldUser.Location = newUser.Location;
            oldUser.Address = newUser.Address;
            oldUser.Phone = newUser.Phone;
            oldUser.SocialLink = newUser.SocialLink;
            oldUser.BirthDate = newUser.BirthDate;
            oldUser.Description = newUser.Description;

            var updateUserResult = Update(oldUser);
            if (!updateUserResult)
            {
                throw new InternalServerErrorException($"Không thể update cho userOutput {JsonConvert.SerializeObject(newUser)}");
            }

            return oldUser;
        }

        #endregion

        #region Common

        private void SetRoleForUser(Guid userId, string roleName)
        {
            var role = _roleService.First(r => r.Name.Equals(roleName));
            _userRoleService.Create(new UserRole { UserId = userId, RoleId = role.Id }, out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException($"Could not create role {roleName}");
            }
        }

        #endregion
    }
}
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
            var user = InitUserNameAndPassword(authDto);
            CheckIfAccountExisted(user.UserName);
            CreateUser(user);
            SetRoleForUser(user.Id, DefaultRole.User);
            return new BaseResponse<string>(HttpStatusCode.OK, data: "Registered successfully");
        }

        private static User InitUserNameAndPassword(UserInputDto authDto)
        {
            var user = Mapper.Map<User>(authDto);
            user.UserName = authDto.Email;
            user.EncodePassword("Sioux@Asia");
            return user;
        }

        private void CheckIfAccountExisted(string userName)
        {
            if (Contains(u => u.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new BadRequestException($"Account with user name {userName} is already existed");
            }
        }

        private void CreateUser(User user)
        {
            Create(user, out var isSaved);
            if (!isSaved)
            {
                throw new InternalServerErrorException($"Could not create user {user.UserName}");
            }
        }

        #endregion

        #region Login

        public BaseResponse<Passport> Login(AuthDto authDto)
        {
            var user = FindUser(authDto.UserName);
            CheckUserPassword(authDto.Password, user);
            var passport = CreatePassport(user);
            return new SuccessResponse<Passport>(passport);
        }

        private User FindUser(string userName)
        {
            var user = Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .Include(x => x.UserPositions).ThenInclude(x => x.Position)
                .Include(x => x.UserSkills).ThenInclude(x => x.Skill)
                .FirstOrDefault(u => u.IsActivated() && u.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
            if (user == null)
            {
                throw new BadRequestException("Wrong User Name");
            }
            return user;
        }

        private static void CheckUserPassword(string password, User user)
        {
            var hash = PasswordHelper.ComputeHash(password, user.PasswordSalt);
            if (!user.PasswordHash.SequenceEqual(hash))
            {
                throw new BadRequestException("Wrong Password");
            }
        }

        private static Passport CreatePassport(User user)
        {
            var userOutput = Mapper.Map<UserOutputDto>(user);
            var token = JwtHelper.CreateToken(userOutput);
            return new Passport {Token = token.AccessToken, Profile = userOutput};
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
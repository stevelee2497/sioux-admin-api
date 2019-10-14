using System;

namespace DAL.Constants
{
	public static class Error
	{
		public const string BadRequest = "Bad Request";
		public const string NotFound = "Not Found";
		public const string InternalServerError = "Internal Server Error";
		public const string BlockedUser = "UserHasBeenBlocked";
		public const string InvalidInput = "Invalid Input";
		public const string CreateError = "Could not create entity {0}";
	}

	public static class DefaultRole
	{
		public const string Admin = "Admin";
		public const string User = "User";
	}

	public static class SortType
	{
		public const string Ascending = "asc";
		public const string Descending = "desc";
	}

	public static class Jwt
	{
		public const string Secret = "If you are wondering what is it about, then just ignore it :)))))))))";
		public const string DefaultScheme = "JwtBearer";
		public const string Issuer = "sioux admin page";
		public const string Audience = "Everyone";
		public static readonly TimeSpan TokenLifetime = TimeSpan.FromDays(30);
	}

    public static class AppConstant
    {
        public const string ContentType = "application/json";
    }
}
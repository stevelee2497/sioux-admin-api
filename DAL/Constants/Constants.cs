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

	public static class BookType
	{
		public const string NewBooks = "new";
		public const string RecommendingBooks = "recommending";
		public const string TrendingBooks = "trending";
		public const string FeaturingBooks = "featuring";
	}

	public static class Jwt
	{
		// TODO: Consider moving to SecretManager
		// https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?tabs=visual-studio
		public const string Secret = "If you are wondering what is it about, then just ignore it :)))))))))";
		public const string DefaultScheme = "JwtBearer";
		public const string Issuer = "busach";
		public const string Audience = "Everyone";
		public static readonly TimeSpan TokenLifetime = TimeSpan.FromDays(30);
	}
}
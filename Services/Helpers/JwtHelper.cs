using DAL.Constants;
using DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Services.DTOs.Output;

namespace Services.Helpers
{
	public static class JwtHelper
	{
		private static readonly SymmetricSecurityKey SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Secret));

		private static readonly JwtSecurityTokenHandler Handler = new JwtSecurityTokenHandler();

		public static Token CreateToken(UserOutputDto profile)
        {
            var header = new JwtHeader(new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256));
            var payload = new JwtPayload(
                Jwt.Issuer,
                Jwt.Audience,
                CreateClaims(profile),
                DateTime.UtcNow,
                DateTime.UtcNow + Jwt.TokenLifetime
            );
            var token = new JwtSecurityToken(header, payload);
			var refreshToken = Guid.NewGuid().ToString().Replace("-", "") + "." + profile.Id;
			var accessToken = new Token
			{
				AccessToken = Handler.WriteToken(token),
				Type = "bearer",
				RefreshToken = refreshToken,
				Expires = token.ValidTo
			};
			return accessToken;
		}

        public static void ConfigureAuthenticationOptions(AuthenticationOptions options)
		{
			options.DefaultAuthenticateScheme = Jwt.DefaultScheme;
			options.DefaultChallengeScheme = Jwt.DefaultScheme;
		}

		public static void ConfigureJwtBearerOptions(JwtBearerOptions options)
			=> options.TokenValidationParameters =
				new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = SecretKey,
					ValidateIssuer = true,
					ValidIssuer = Jwt.Issuer,
					ValidateAudience = true,
					ValidAudience = Jwt.Audience,
					ValidateLifetime = true,
					ClockSkew = Jwt.TokenLifetime,
					LifetimeValidator = LifetimeValidator
				};

		public static bool LifetimeValidator(DateTime? from, DateTime? to, SecurityToken token,
			TokenValidationParameters options)
		{
			// If some parameters are missing, token is considered invalid
			if (!from.HasValue || !to.HasValue || token == null || options == null)
				return false;

			// If token is expired, it's considered invalid
			if (to.Value + options.ClockSkew < DateTime.UtcNow)
				return false;

			// If token is not jwt, it's considered invalid
			if (!(token is JwtSecurityToken jwtToken))
			{
				return false;
			}

			// If token doesn't contain userOutput id, it's considered invalid
			var user = DictionaryHelper.ToObject<User>(jwtToken.Payload.ToDictionary(p => p.Key, p => p.Value));

			if (user == null)
			{
				return false;
			}

			// If token is issue before the allowed date, it's considered invalid
			if (from + options.ClockSkew < user.AllowTokensSince)
			{
				return false;
			}

			return true;
		}

        private static IEnumerable<Claim> CreateClaims(UserOutputDto profile)
        {
            yield return new Claim(ClaimTypes.Sid, profile.Id);
            foreach (var role in profile.Roles)
            {
                yield return new Claim(ClaimTypes.Role, role.RoleName);
            }
        }
    }
}
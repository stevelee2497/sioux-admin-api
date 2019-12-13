using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using DAL.Constants;

namespace Services.Extensions
{
	public static class ClaimsExtensions
	{
		public static Guid GetUserId(this IEnumerable<Claim> claims)
			=> Guid.TryParse(GetClaimValue(claims, ClaimTypes.Sid), out Guid id)
				? id
				: throw new AuthenticationException($"Cannot read claim [{ClaimTypes.Sid}]");

		public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
			=> claimsPrincipal.Claims.GetUserId();

        public static string GetRole(this ClaimsPrincipal claimsPrincipal)
        {
            var roles = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).ToList();
            if (!roles.Any())
            {
                throw new AuthenticationException("Token does not contain claim role");
            }

			return roles.Any(x => x.Value == DefaultRole.Admin) ? DefaultRole.Admin : DefaultRole.User;
        }

		private static string GetClaimValue(this IEnumerable<Claim> claims, string claimType)
		{
			var claim = claims.FirstOrDefault(x => x.Type == claimType);
			if (claim == null) throw new AuthenticationException($"Token does not contain claim [{claimType}]");
			return claim.Value;
		}
	}
}

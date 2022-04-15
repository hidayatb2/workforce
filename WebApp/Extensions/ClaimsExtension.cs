using SharedLibrary;
using System.Security.Claims;

namespace WebApp
{
    public static class ClaimsExtension
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (Guid.TryParse(principal?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.UserId).Value, out Guid userId))
                return userId;
            return Guid.Empty;
        }
    }
}

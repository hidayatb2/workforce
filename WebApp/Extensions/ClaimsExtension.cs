using Models;
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

        public static string? GetName(this ClaimsPrincipal principal)
        {
            return principal?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.Name)?.Value;
        }

        public static string? GetRole(this ClaimsPrincipal principal)
        {
            
              var x =  principal?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.Role)?.Value;
            return x;
        }

     
    }
}

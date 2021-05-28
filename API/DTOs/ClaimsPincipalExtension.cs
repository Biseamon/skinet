using System.Linq;
using System.Security.Claims;

namespace API.DTOs
{
    public static class ClaimsPincipalExtension
    {
       public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
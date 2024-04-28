using System.Security.Claims;

namespace VM.Marketplace.API.Extensions;

public static class HttpContextExtension
{
    public static Guid GetIdentityUserId(this HttpContext context)
    {
        return Guid.Parse(GetGuidClaimValue("IdentityUserId", context));
    }

    public static string GetUserName(this HttpContext context)
    {

        return GetGuidClaimValue("UserName", context);
    }

    public static string GetEmail(this HttpContext context)
    {
        return GetGuidClaimValue("Email", context);
    }

    private static string GetGuidClaimValue(string key, HttpContext context)
    {
        var identity = context.User.Identity as ClaimsIdentity;
        return identity?.FindFirst(key)?.Value;
    }
}

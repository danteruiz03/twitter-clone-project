namespace Dante.API.Utilities;

public static class ExtensionMethods
{
    public static string? GetUserId(this HttpContext httpContext)
    {
        return httpContext.User.Claims
            .FirstOrDefault(claim => claim.Type == "UserID")?.Value;
    }
}
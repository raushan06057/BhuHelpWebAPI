namespace BhuHelpAPI.Application.Middlewares.Extension;

public static class AuthenticationMiddlewareExtension
{
    public static void UseAuthenticationHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<AuthenticationMiddleware>();
    }
}
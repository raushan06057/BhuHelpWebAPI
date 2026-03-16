namespace BhuHelpAPI.Application.Middlewares;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuthenticationMiddleware> _logger;
    private readonly IConfiguration config;
    public AuthenticationMiddleware(RequestDelegate next,ILogger<AuthenticationMiddleware> logger,IConfiguration config)
    {
        _next = next;
        _logger = logger;
        this.config = config;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        string authHeader = Convert.ToString(context.Request.Headers[CommonFields.Authorization]);
        
        if (!string.IsNullOrEmpty(authHeader)) 
        {
            var token = context.Request.Headers[CommonFields.Authorization].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrEmpty(token) && token!=CommonFields.Header)
            {
                AttachAccountToContext(context, token);
            }
        }
        await _next(context);
    }

    private void AttachAccountToContext(HttpContext context,string token) 
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Convert.ToString(config[CommonFields.JwtColonKey]));
        var issuer = config[CommonFields.JwtColonIssuer];
        var audience = config[CommonFields.JwtColonAudience];
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = issuer,
            ValidAudience = audience
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var accountId=jwtToken.Claims.First(mod=>mod.Type==CommonFields.ID).Value;
        var role = jwtToken.Claims.First(mod=>mod.Type==ClaimTypes.Role).Value;
        context.Items[CommonFields.UserId] = accountId;
    }
}

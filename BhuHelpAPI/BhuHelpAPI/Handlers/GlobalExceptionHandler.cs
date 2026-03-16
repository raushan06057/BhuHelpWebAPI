namespace BhuHelpAPI.Handlers;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError("Exception occured :" + exception.Message);
        var problemDetails = new ProblemDetails
        {
            Status = httpContext.Response.StatusCode,
            Title = exception.Message,
            Detail = exception.StackTrace
        };
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}

public class ExaptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExaptionMiddleware> _logger;

    public ExaptionMiddleware(RequestDelegate next, ILogger<ExaptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            switch (ex.GetType())
            {
                case Type exType when exType == typeof(NullReferenceException):
                    context.Response.StatusCode = 401;
                    _logger.Log(LogLevel.Critical, 1, "NullReferenceException: " + ex.Message);
                    break;
                default:
                    _logger.Log(LogLevel.Critical, ex.Message);
                    break;
            }
        }
    }
}
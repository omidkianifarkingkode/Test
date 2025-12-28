using System.Net;
using System.Text.Json;

namespace ShopLite.Presentation.Middlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    
    public async Task InvokeAsync(HttpContext context)
    {
        // TODO : implement this method.
        // Requirements:
        // - Wrap _next(context) in try/catch.
        // - On exception, log it and call HandleExceptionAsync.
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "UnHandled exception");
            await HandleExceptionAsync(context, e);
        }

    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        string error;

        switch (exception)
        {
            case ArgumentException:
                status = HttpStatusCode.BadRequest;
                error = "BadRequest";
                break;

            case InvalidOperationException:
                status = HttpStatusCode.NotFound;
                error = "NotFound";
                break;

            default:
                status = HttpStatusCode.InternalServerError;
                error = "InternalServerError";
                break;
        }

        var response = new
        {
            error,
            message = exception.Message
        };

        var payload = JsonSerializer.Serialize(response);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        return context.Response.WriteAsync(payload);
    }
}

using System.Net;
using System.Text.Json;
using ELYA.Api.Models;
using ELYA.Application.Common.Exceptions;
namespace ELYA.Api.Middleware;

public sealed class GlobalExceptionMiddleware
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, response) = MapException(exception);

        if (statusCode == (int)HttpStatusCode.InternalServerError)
        {
            _logger.LogError(exception, "Unhandled system error.");
        }
        else
        {
            _logger.LogWarning(exception, "Handled application error.");
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, JsonOptions));
    }

    private (int StatusCode, ApiResponse<object> Response) MapException(Exception exception)
    {
        return exception switch
        {
            ValidationException validation => (
                StatusCodes.Status400BadRequest,
                ApiResponse<object>.Fail(validation.Message, validation.Errors)),

            UnauthorizedException unauthorized => (
                StatusCodes.Status401Unauthorized,
                ApiResponse<object>.Fail(unauthorized.Message)),

            ForbiddenException forbidden => (
                StatusCodes.Status403Forbidden,
                ApiResponse<object>.Fail(forbidden.Message)),

            NotFoundException notFound => (
                StatusCodes.Status404NotFound,
                ApiResponse<object>.Fail(notFound.Message)),

            ConflictException conflict => (
                StatusCodes.Status409Conflict,
                ApiResponse<object>.Fail(conflict.Message)),

            SystemErrorException systemError => (
                StatusCodes.Status500InternalServerError,
                ApiResponse<object>.Fail(systemError.Message)),

            _ => (
                StatusCodes.Status500InternalServerError,
                ApiResponse<object>.Fail("An unexpected error occurred."))
        };
    }
}

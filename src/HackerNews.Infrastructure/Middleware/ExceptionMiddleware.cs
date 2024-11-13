using HackerNews.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace HackerNews.Infrastructure.Middleware;

internal sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var name = exception.GetType().Name;
        var (statusCode, error) = exception switch
        {
            //add more exceptions to send 404 codes etc.
            HackerNewsException => (StatusCodes.Status400BadRequest, new Error(name.Remove(name.LastIndexOf("Exception", StringComparison.Ordinal), "Exception".Length), exception.Message)),
            _ => (StatusCodes.Status500InternalServerError, new Error("error", $"Something went wrong. Contact support @ no-reply@hackernews.com.")),
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }

    private record Error(string Code, string Reason);
}
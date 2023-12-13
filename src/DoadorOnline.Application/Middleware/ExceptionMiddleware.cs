using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace DoadorOnline.Application;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    private readonly IHostEnvironment _hostEnvironment;
    public ExceptionMiddleware(RequestDelegate next,
                               ILogger<ExceptionMiddleware> logger,
                               IHostEnvironment hostEnvironment)
    {
        this._next = next;
        this._logger = logger;
        this._hostEnvironment = hostEnvironment;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await this._next(httpContext);
        }
        catch (UnauthorizedAccessException ex)
        {
            await this.HandleExceptionAsync(
                httpContext,
                new ResponseResult
                {
                    Title = "Unauthorized Access Error.",
                    Status = (int)HttpStatusCode.Unauthorized,
                    Errors = new ResponseErrorMessages(ex.Message)
                });
        }
        catch (ValidationException ex)
        {
            await this.HandleExceptionAsync(
                httpContext,
                new ResponseResult
                {
                    Title = "Validation Error",
                    Status = (int)HttpStatusCode.BadRequest,
                    Errors = new ResponseErrorMessages(ex.Errors)
                });
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, ex.Message);

            var response = ex.Message;

            await this.HandleExceptionAsync(
                httpContext,
                new ResponseResult
                {
                    Title = "Internal Server Error.",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Errors = new ResponseErrorMessages(response)
                });
        }
    }
    private async Task HandleExceptionAsync(HttpContext context,
                                            ResponseResult responseResult)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = responseResult.Status;
        await context.Response.WriteAsync(JsonSerializer.Serialize(responseResult));
    }
}


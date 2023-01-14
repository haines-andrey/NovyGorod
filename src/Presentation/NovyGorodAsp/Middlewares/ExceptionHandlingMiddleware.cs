using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using NovyGorod.Common.Exceptions;

namespace NovyGorodAsp.Middlewares;

internal class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    private static readonly IReadOnlyDictionary<ErrorCode, int> ErrorCodesMapping =
        new Dictionary<ErrorCode, int>
        {
            {ErrorCode.UnhandledException, StatusCodes.Status500InternalServerError},
            {ErrorCode.ValidationFailed, StatusCodes.Status400BadRequest},
            {ErrorCode.EntityNotFound, StatusCodes.Status404NotFound},
        };

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleException(context, ex, next);
        }
    }

    private async Task HandleException(HttpContext context, Exception exception, RequestDelegate next)
    {
        if (exception is not CodedException codedException ||
            !ErrorCodesMapping.ContainsKey(codedException.Code))
        {
            await SetError(context, next);

            return;
        }

        await SetError(context, next, codedException.Code);
    }

    private async Task SetError(HttpContext context, RequestDelegate next, ErrorCode? errorCode = null)
    {
        ClearHttpContext(context);
        context.Response.StatusCode = errorCode.HasValue
            ? ErrorCodesMapping[errorCode.Value]
            : StatusCodes.Status500InternalServerError;
        await ViewErrorPage(context, next, errorCode);
    }

    private async Task ViewErrorPage(HttpContext context, RequestDelegate next, ErrorCode? errorCode)
    {
        var originalPath = context.Request.Path;
        context.Request.Path = new PathString($"/error/{(int)errorCode.GetValueOrDefault()}");
        await next(context);
        context.Request.Path = originalPath;
    }

    private static void ClearHttpContext(HttpContext context)
    {
        context.Response.Clear();
        context.SetEndpoint(endpoint: null);
        var routeValuesFeature = context.Features.Get<IRouteValuesFeature>();

        if (routeValuesFeature != null)
        {
            routeValuesFeature.RouteValues = null!;
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NovyGorod.Common.Exceptions;
using NovyGorodAsp.Models.Error;

namespace NovyGorodAsp.Controllers;

[Route("[controller]")]
public class ErrorController : Controller
{
    private readonly IReadOnlyDictionary<ErrorCode, Func<ErrorCode, ErrorViewModel>> _viewModelFactories =
        new Dictionary<ErrorCode, Func<ErrorCode, ErrorViewModel>>
        {
            {ErrorCode.Unauthenticated, code => new ErrorViewModel {Code = code}},
            {ErrorCode.Unauthorized, code => new ErrorViewModel {Code = code}},
            {ErrorCode.UnhandledException, code => new ErrorViewModel {Code = code}},
            {ErrorCode.ValidationFailed, code => new ThinkingErrorViewModel {Code = code}},
            {ErrorCode.EntityNotFound, code => new SearchingErrorViewModel {Code = code}},
            {ErrorCode.RouteNotFound, code => new SearchingErrorViewModel {Code = code}},
        };

    [HttpGet("{errorCode}")]
    public IActionResult Index(ErrorCode errorCode)
    {
        var factory = _viewModelFactories.ContainsKey(errorCode)
            ? _viewModelFactories[errorCode]
            : _viewModelFactories[ErrorCode.UnhandledException];

        var viewModel = factory(errorCode);

        return View(viewModel);
    }
}
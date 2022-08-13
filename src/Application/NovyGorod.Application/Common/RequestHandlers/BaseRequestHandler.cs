using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Common.RequestHandlers;

public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IExecutionContextService _executionContextService;

    protected BaseRequestHandler(IExecutionContextService executionContextService)
    {
        _executionContextService = executionContextService;
    }

    protected int CurrentLanguageId { get; private set; }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await FetchDataFromContext();

        return await HandleInternal(request, cancellationToken);
    }

    protected abstract Task<TResponse> HandleInternal(TRequest request, CancellationToken cancellationToken);

    private async Task FetchDataFromContext()
    {
        CurrentLanguageId = await _executionContextService.GetCurrentLanguageId();
    }
}
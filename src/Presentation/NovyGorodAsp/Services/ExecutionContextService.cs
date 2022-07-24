using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NovyGorod.Application.Common.Queries;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Services;

namespace NovyGorodAsp.Services;

public class ExecutionContextService : IExecutionContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExecutionContextService(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public IEntityAccessService<Language> LanguageAccessService { get; set; }

    public Task<int> GetCurrentLanguageId()
    {
        var code = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        var query = new LanguageQueryParameters {Code = code};

        return LanguageAccessService.GetSingleOrDefault(query, x => x.Id);
    }

    public string GetCurrentUrl()
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        var scheme = request?.Scheme;
        var host = request?.Host.Value;
        
        return $"{scheme}://{host}";
    }
}
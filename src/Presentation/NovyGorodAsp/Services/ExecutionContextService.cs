using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
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
    
    public IReadOnlyRepository<Language> LanguageRepository { get; set; }

    public Task<int> GetCurrentLanguageId()
    {
        var code = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        var query = QueryBuilder<Language>.CreateWithFilter(lang => lang.Code == code).Build();

        return LanguageRepository.GetSingleOrDefault(query, x => x.Id);
    }

    public string GetCurrentUrl()
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        var scheme = request?.Scheme;
        var host = request?.Host.Value;
        
        return $"{scheme}://{host}";
    }
}
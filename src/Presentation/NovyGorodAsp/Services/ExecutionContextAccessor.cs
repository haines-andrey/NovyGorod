using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Services;

namespace NovyGorodAsp.Services;

public class ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor) : IExecutionContextAccessor
{
    public IReadOnlyRepository<Language> LanguageRepository { get; set; }

    public Task<int> GetCurrentLanguageId()
    {
        var code = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        var query = QueryBuilder<Language>.CreateNew().Where(Filters.Language.CodeIs(code)).Build();

        return LanguageRepository.GetSingleOrDefault(query, lang => lang.Id);
    }

    public string GetCurrentUrl()
    {
        var request = httpContextAccessor.HttpContext?.Request;
        var scheme = request?.Scheme;
        var host = request?.Host.Value;

        return $"{scheme}://{host}";
    }
}
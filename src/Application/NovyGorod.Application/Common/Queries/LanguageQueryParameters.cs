using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Common.Queries;

public class LanguageQueryParameters : BaseQueryParameters<Language>
{
    public string Code { get; set; }

    protected override void AddFilters()
    {
        
        Filter(language => language.Code == Code);
    }
}
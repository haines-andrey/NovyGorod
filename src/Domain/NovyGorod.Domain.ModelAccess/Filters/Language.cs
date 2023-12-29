using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries;
using LanguageModel = NovyGorod.Domain.Models.Common.Language;

namespace NovyGorod.Domain.ModelAccess.Filters;

public static class Language
{
    public static QueryFilter<LanguageModel> IdIs(int id) =>
        Common.IdIs<LanguageModel>(id);

    public static QueryFilter<LanguageModel> IdIsIn(IEnumerable<int> ids) =>
        Common.IdIsIn<LanguageModel>(ids);

    public static QueryFilter<LanguageModel> CodeIs(string code) =>
        Create(language => language.Code.Equals(code));

    private static QueryFilter<LanguageModel> Create(Expression<Func<LanguageModel, bool>> expression) =>
        QueryFilter<LanguageModel>.Create(expression);
}
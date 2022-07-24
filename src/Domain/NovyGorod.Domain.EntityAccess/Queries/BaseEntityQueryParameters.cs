using System.Diagnostics.CodeAnalysis;
using NovyGorod.Common.Extensions;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.EntityAccess.Queries;

[ExcludeFromCodeCoverage]
public class BaseEntityQueryParameters<TEntity> : BaseQueryParameters<TEntity>
    where TEntity : IBaseEntity
{
    public int Id { get; set; }

    public HashSet<int> Ids { get; set; }

    protected override void AddFilters()
    {
        if (!Ids.IsNullOrEmpty())
        {
            Filter(x => Ids.Contains(x.Id));
        }
        else
        {
            Filter(x => x.Id == Id);
        }
    }
}
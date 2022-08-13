using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using NovyGorod.Domain.EntityAccess.Queries.Builders;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Domain.EntityAccess.Queries;

[ExcludeFromCodeCoverage]
public abstract class BaseQueryParameters<TEntity> : IQueryParameters<TEntity>
{
    private readonly IQueryBuilder<TEntity> _builder = new QueryBuilder<TEntity>();
    
    public bool IsReadOnly { get; set; }

    Query<TEntity> IQueryParameters<TEntity>.ToQuery()
    {
        AddFilters();
        SkipFilters();
        AddSorting();
        AddPaging();

        return _builder.AsReadOnly(IsReadOnly).ToQuery();
    }

    protected void FilterIf(bool condition, Expression<Func<TEntity, bool>> predicate)
    {
        if (condition)
        {
            Filter(predicate);
        }
    }

    protected void Filter(Expression<Func<TEntity, bool>> predicate)
    {
        _builder.AndWhere(predicate);
    }

    protected void OrFilter(Expression<Func<TEntity, bool>> predicate)
    {
        _builder.OrWhere(predicate);
    }

    protected void Sort<TKey>(OrderType orderType, Expression<Func<TEntity, TKey>> keySelector)
    {
        _builder.Ordering(orderType, keySelector);
    }

    protected void SortIf<TKey>(bool predicate, OrderType orderType, Expression<Func<TEntity, TKey>> keySelector)
    {
        if (predicate)
        {
            Sort(orderType, keySelector);
        }
    }

    protected void SkipIfNeeded(bool shouldSkip, IEnumerable<string> filters)
    {
        if (shouldSkip)
        {
            _builder.AddExcludedFilters(filters.ToArray());
        }
    }

    protected void Paging(Paging paging)
    {
        _builder.Paging(paging);
    }

    protected virtual void AddFilters()
    {
    }

    protected virtual void SkipFilters()
    {
    }

    protected virtual void AddSorting()
    {
    }

    protected virtual void AddPaging()
    {
    }
}
namespace NovyGorod.Domain.EntityAccess.Queries;

public interface IQueryParameters<TEntity>
{
    internal Query<TEntity> ToQuery();
}
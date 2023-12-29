namespace NovyGorod.Domain.ModelAccess;

public interface IRepository<TModel> : IReadOnlyRepository<TModel>
    where TModel : class
{
    Task<TModel> Add(TModel model, CancellationToken cancellationToken = default);

    Task Add(IEnumerable<TModel> models, CancellationToken cancellationToken = default);

    Task<TModel> Update(TModel model, CancellationToken cancellationToken = default);

    Task Update(IEnumerable<TModel> models, CancellationToken cancellationToken = default);

    Task Delete(TModel model, CancellationToken cancellationToken = default);

    Task Delete(IEnumerable<TModel> models, CancellationToken cancellationToken = default);
}
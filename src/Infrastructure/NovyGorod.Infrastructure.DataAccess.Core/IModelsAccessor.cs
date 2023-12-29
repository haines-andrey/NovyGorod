namespace NovyGorod.Infrastructure.DataAccess.Core;

public interface IModelsAccessor
{
    IEnumerable<TModel> GetModels<TModel>(ModelState state)
        where TModel : class;

    Task<int> SaveModels(CancellationToken cancellationToken = default);
}

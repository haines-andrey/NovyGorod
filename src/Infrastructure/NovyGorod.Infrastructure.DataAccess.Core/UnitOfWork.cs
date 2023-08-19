using NovyGorod.Common.Extensions;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;
using NovyGorod.Infrastructure.DataAccess.Core.RepositoryFactories;

namespace NovyGorod.Infrastructure.DataAccess.Core;

internal class UnitOfWork : IUnitOfWork
{
    private readonly IDataAccessProvider _dataAccessProvider;
    private readonly IRepositoryFactory _repositoryFactory;
    private readonly IEnumerable<IBeforeCommitHandler> _beforeCommitHandlers;

    public UnitOfWork(
        IDataAccessProvider dataAccessProvider,
        IRepositoryFactory repositoryFactory,
        IEnumerable<IBeforeCommitHandler> beforeCommitHandlers)
    {
        _dataAccessProvider = dataAccessProvider;
        _repositoryFactory = repositoryFactory;
        _beforeCommitHandlers = beforeCommitHandlers;
    }

    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class
    {
        return _repositoryFactory.GetGenericRepository<TEntity>();
    }

    public async Task<int> Commit(CancellationToken cancellationToken = default)
    {
        await _beforeCommitHandlers.ForEachOneByOneAsync(h => h.Handle(_dataAccessProvider));

        return await _dataAccessProvider.Commit(cancellationToken);
    }
}
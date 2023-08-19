namespace NovyGorod.Domain.ModelAccess;

public interface IUnitOfWork : ICommitter
{
    IRepository<TModel> GetRepository<TModel>()
        where TModel : class;
}
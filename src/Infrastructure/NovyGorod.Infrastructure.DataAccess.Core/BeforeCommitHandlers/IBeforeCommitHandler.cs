namespace NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;

public interface IBeforeCommitHandler
{
    Task Handle(IDataAccessProvider dataAccessProvider);
}
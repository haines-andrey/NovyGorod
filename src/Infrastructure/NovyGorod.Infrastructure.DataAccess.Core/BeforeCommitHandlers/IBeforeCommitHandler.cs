using NovyGorod.Domain.EntityAccess;

namespace NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;

public interface IBeforeCommitHandler
{
    Task OnBeforeCommitAsync(IUnitOfWork unitOfWork, IDataAccessProvider dataAccessProvider);
}
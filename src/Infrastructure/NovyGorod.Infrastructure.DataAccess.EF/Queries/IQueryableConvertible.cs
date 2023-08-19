using System.Linq;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries;

public interface IQueryableConvertible<out T>
{
    IQueryable<T> ToQueryable();
}
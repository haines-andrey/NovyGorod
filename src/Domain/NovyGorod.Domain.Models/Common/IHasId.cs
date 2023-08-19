namespace NovyGorod.Domain.Models.Common;

public interface IHasId<T>
{
    T Id { get; set; }

    bool IsNew => Id.Equals(default);
}
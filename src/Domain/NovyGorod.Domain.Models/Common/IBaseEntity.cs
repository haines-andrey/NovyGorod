namespace NovyGorod.Domain.Models.Common;

public interface IBaseEntity
{
    int Id { get; set; }

    bool IsNew { get; }
}
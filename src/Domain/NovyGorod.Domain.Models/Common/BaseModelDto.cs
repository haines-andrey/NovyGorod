namespace NovyGorod.Domain.Models.Common;

public record BaseModelDto : IHasId<int>
{
    public int Id { get; set; }
}
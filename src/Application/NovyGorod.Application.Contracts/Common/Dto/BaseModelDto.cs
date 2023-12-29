using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Contracts.Common.Dto;

public record BaseModelDto : IHasId<int>
{
    public int Id { get; set; }
}
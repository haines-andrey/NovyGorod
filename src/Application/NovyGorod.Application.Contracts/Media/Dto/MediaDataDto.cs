using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Contracts.Media.Dto;

public record MediaDataDto : BaseEntityDto
{
    public MediaDataType Type { get; init; }

    public string Url { get; init; }
}
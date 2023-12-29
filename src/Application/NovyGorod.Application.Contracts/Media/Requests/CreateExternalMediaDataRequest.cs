using MediatR;
using NovyGorod.Application.Contracts.Common.Dto;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Contracts.Media.Requests;

public record CreateExternalMediaDataRequest : IRequest<BaseModelDto>
{
    public string Url { get; init; }

    public MediaDataType Type { get; init; }
}
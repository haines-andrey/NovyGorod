using MediatR;

namespace NovyGorod.Application.Contracts.Media.Requests;

public record GetMediaDataRequest : IRequest<FileStream>
{
    public int Id { get; init; }
}
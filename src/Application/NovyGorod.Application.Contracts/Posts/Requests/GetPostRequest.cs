using MediatR;
using NovyGorod.Application.Contracts.Common;
using NovyGorod.Application.Contracts.Posts.Dto;

namespace NovyGorod.Application.Contracts.Posts.Requests;

public record GetPostRequest : IRequest<PostDto>, IHasLanguageId
{
    public int Id { get; init; }

    public int LanguageId { get; init; }
}
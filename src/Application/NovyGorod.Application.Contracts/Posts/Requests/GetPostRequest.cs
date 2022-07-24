using MediatR;
using NovyGorod.Application.Contracts.Posts.Dto;

namespace NovyGorod.Application.Contracts.Posts.Requests;

public record GetPostRequest : IRequest<PostDto>
{
    public int Id { get; init; }
}
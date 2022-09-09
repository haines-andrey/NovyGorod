using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Dto;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Contracts.Posts.Dto;

public record PostDto : BaseEntityDto
{
    public PostType Type { get; init; }

    public string Title { get; init; }
        
    public string Summary { get; init; }

    public MediaDataDto Preview { get; init; }

    public MediaDataDto Video { get; init; }

    public DateTimeOffset CreatedAt { get; init; }
    
    public virtual ICollection<PostBlockDto> Blocks { get; init; }
}
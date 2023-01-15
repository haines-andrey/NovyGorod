using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostTypeLink
{
    public PostType Type { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; }
}
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostTranslation : BaseEntity, ITranslationOfEntity<Post>
{
    public string Title { get; set; }
        
    public string Summary { get; set; }

    public int PreviewId { get; set; }

    public virtual MediaData Preview { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

    public int EntityId { get; set; }

    public virtual Post Entity { get; set; }
}
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostBlockTranslation : BaseEntity, ITranslationOfEntity<PostBlock>
{
    public string Title { get; set; }
    
    public string Text { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

    public int EntityId { get; set; }

    public virtual PostBlock Entity { get; set; }
}
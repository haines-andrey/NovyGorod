using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostTranslation : TranslationOfModel<Post>
{
    public string Title { get; set; }

    public string Summary { get; set; }

    public int PreviewId { get; set; }

    public virtual MediaData Preview { get; set; }
    
    public int? VideoId { get; set; }

    public virtual MediaData Video { get; set; }
}
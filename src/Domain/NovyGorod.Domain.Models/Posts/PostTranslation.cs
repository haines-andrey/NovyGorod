using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostTranslation : ITranslationOfModel<Post, int>
{
    public string Title { get; set; }
        
    public string Summary { get; set; }

    public int PreviewId { get; set; }

    public virtual MediaData Preview { get; set; }

    public int? VideoId { get; set; }

    public virtual MediaData Video { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

    public int ModelId { get; set; }

    public virtual Post Model { get; set; }
}
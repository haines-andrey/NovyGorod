using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostBlockTranslation : ITranslationOfModel<PostBlock, int>
{
    public string Title { get; set; }
    
    public string Text { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

    public int ModelId { get; set; }

    public virtual PostBlock Model { get; set; }
}
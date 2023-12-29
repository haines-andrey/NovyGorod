using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostBlockTranslation : TranslationOfModel<PostBlock>
{
    public string Title { get; set; }
    
    public string Text { get; set; }
}
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models.Attachments;

[ExcludeFromCodeCoverage]
public class AttachmentTranslation : BaseEntity, ITranslationOfEntity<Attachment>
{
    public int? PreviewMediaId { get; set; }

    public virtual MediaData PreviewMedia { get; set; }
    
    public int SourceMediaId { get; set; }

    public virtual MediaData SourceMedia { get; set; }

    public string Summary { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

    public int EntityId { get; set; }

    public virtual Attachment Entity { get; set; }
}
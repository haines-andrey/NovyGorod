using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models.Attachments;

[ExcludeFromCodeCoverage]
public class AttachmentTranslation : ITranslationOfModel<Attachment, int>
{
    public int? PreviewMediaId { get; set; }

    public virtual MediaData PreviewMedia { get; set; }
    
    public int SourceMediaId { get; set; }

    public virtual MediaData SourceMedia { get; set; }

    public string Summary { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

    public int ModelId { get; set; }

    public virtual Attachment Model { get; set; }
}
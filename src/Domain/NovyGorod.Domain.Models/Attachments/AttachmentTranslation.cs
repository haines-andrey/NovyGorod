using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Domain.Models.Attachments;

[ExcludeFromCodeCoverage]
public class AttachmentTranslation : TranslationOfBaseModel<Attachment>
{
    public int? PreviewMediaId { get; set; }

    public virtual MediaData PreviewMedia { get; set; }

    public int SourceMediaId { get; set; }

    public virtual MediaData SourceMedia { get; set; }

    public string Summary { get; set; }
}
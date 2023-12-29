using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Common.Translations;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Domain.Models.Attachments;

[ExcludeFromCodeCoverage]
public class Attachment : ITranslatedModel<Attachment, AttachmentTranslation>, ISequencedModel
{
    public int Id { get; set; }

    public int Index { get; set; }

    public int BlockId { get; set; }

    public virtual PostBlock Block { get; set; }

    public virtual ICollection<AttachmentTranslation> Translations { get; set; }
}
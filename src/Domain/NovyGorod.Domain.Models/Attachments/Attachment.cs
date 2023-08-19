using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Domain.Models.Attachments;

[ExcludeFromCodeCoverage]
public class Attachment : BaseModel, ITranslatedModel<Attachment, int, AttachmentTranslation>, ISequencedModel
{
    public int Index { get; set; }

    public int BlockId { get; set; }

    public virtual PostBlock Block { get; set; }

    public virtual ICollection<AttachmentTranslation> Translations { get; set; }
}
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostBlock : ITranslatedModel<PostBlock, PostBlockTranslation>, ISequencedModel
{
    public int Id { get; set; }

    public int Index { get; set; }
        
    public virtual ICollection<Attachment> Attachments { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; }

    public virtual ICollection<PostBlockTranslation> Translations { get; set; }
}
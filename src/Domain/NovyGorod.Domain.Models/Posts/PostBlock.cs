using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class PostBlock : BaseEntity, ITranslatedEntity<PostBlock, PostBlockTranslation>, IIndexedEntity
{
    public int Index { get; set; }
        
    public virtual ICollection<Attachment> Attachments { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; }

    public virtual ICollection<PostBlockTranslation> Translations { get; set; }
}
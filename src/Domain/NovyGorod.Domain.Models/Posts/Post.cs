using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class Post : BaseEntity, ITranslatedEntity<Post, PostTranslation>, IIndexedEntity, ITrackable
{
    public int Index { get; set; }
        
    public PostType Type { get; set; }

    public virtual ICollection<PostBlock> Blocks { get; set; }

    public virtual ICollection<PostTranslation> Translations { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
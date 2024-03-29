﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Domain.Models.Posts;

[ExcludeFromCodeCoverage]
public class Post : ITranslatedModel<Post, PostTranslation>, ISequencedModel, ITrackable
{
    public int Id { get; set; }

    public int Index { get; set; }

    public virtual ICollection<PostTypeLink> TypeLinks { get; set; }

    public virtual ICollection<PostBlock> Blocks { get; set; }

    public virtual ICollection<PostTranslation> Translations { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
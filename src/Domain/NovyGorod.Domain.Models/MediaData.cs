﻿using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.Models;

[ExcludeFromCodeCoverage]
public class MediaData : IHasId<int>
{
    public int Id { get; set; }

    public MediaDataType Type { get; set; }
    
    public bool IsLocal { get; set; }
    
    public string Url { get; set; }
}
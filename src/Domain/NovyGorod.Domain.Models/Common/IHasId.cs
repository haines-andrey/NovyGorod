using System;

namespace NovyGorod.Domain.Models.Common;

public interface IHasId<TId>
    where TId : IEquatable<TId>
{
    TId Id { get; set; }
}
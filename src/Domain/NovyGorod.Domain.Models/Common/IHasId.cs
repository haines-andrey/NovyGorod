using System;

namespace NovyGorod.Domain.Models.Common;

public interface IHasId<T>
    where T : IEquatable<T>
{
    T Id { get; set; }

    bool IsNew => Id.Equals(default);
}
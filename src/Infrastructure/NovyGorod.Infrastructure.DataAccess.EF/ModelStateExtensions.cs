using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NovyGorod.Infrastructure.DataAccess.Core;

namespace NovyGorod.Infrastructure.DataAccess.EF;

internal static class ModelStateExtensions
{
    public static Func<EntityEntry<T>, bool> ToEfEntityStateFilter<T>(this ModelState modelState)
        where T : class
    {
        ISet<EntityState> converted = new HashSet<EntityState>();
        if (modelState.HasFlag(ModelState.Added))
        {
            converted.Add(EntityState.Added);
        }

        if (modelState.HasFlag(ModelState.Deleted))
        {
            converted.Add(EntityState.Deleted);
        }

        if (modelState.HasFlag(ModelState.Modified))
        {
            converted.Add(EntityState.Modified);
        }

        return entityState => converted.Contains(entityState.State);
    }
}
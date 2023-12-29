using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Infrastructure.DataAccess.Core;

namespace NovyGorod.Infrastructure.DataAccess.EF;

internal static class ModelStateExtensions
{
    private static readonly IReadOnlyDictionary<ModelState, EntityState> Mapping =
        new Dictionary<ModelState, EntityState>
        {
            {ModelState.Added, EntityState.Added},
            {ModelState.Modified, EntityState.Modified},
            {ModelState.Deleted, EntityState.Deleted},
        };

    public static EntityState ToEntityState(this ModelState modelState)
    {
        return Mapping[modelState];
    }
}
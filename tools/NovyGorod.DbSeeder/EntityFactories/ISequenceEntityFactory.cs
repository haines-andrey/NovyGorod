using NovyGorod.Domain.Models.Common;

namespace NovyGorod.DbSeeder.EntityFactories;

internal interface ISequenceEntityFactory<TEntity, in TDto>
    where TEntity : ISequencedModel
{
    Task<TEntity> Create(TDto dto, int sequenceNumber);
}
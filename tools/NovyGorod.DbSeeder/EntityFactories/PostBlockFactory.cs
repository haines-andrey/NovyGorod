using NovyGorod.DbSeeder.Dtos;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class PostBlockFactory : ISequenceEntityFactory<PostBlock, PostBlockDto>
{
    private readonly IEntityFactory<PostBlockTranslation, PostBlockDto> _translationFactory;

    public PostBlockFactory(
        IEntityFactory<PostBlockTranslation, PostBlockDto> translationFactory)
    {
        _translationFactory = translationFactory;
    }

    public async Task<PostBlock> Create(PostBlockDto dto, int sequenceNumber)
    {
        var block = new PostBlock
        {
            Index = sequenceNumber,
            Translations = new[] {await CreateTranslation(dto)},
        };

        return block;
    }
    
    private Task<PostBlockTranslation> CreateTranslation(PostBlockDto dto)
    {
        return _translationFactory.Create(dto);
    }
}
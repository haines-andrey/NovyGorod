using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.Services;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class PostFactory : IEntityFactory<Post, PostDto>
{
    private readonly IDefaultDataService _defaultDataService;
    private readonly IEntityFactory<PostTranslation, PostDto> _translationFactory;
    private readonly ISequenceEntityFactory<PostBlock, PostBlockDto> _blockFactory;

    public PostFactory(
        IDefaultDataService defaultDataService,
        IEntityFactory<PostTranslation, PostDto> translationFactory,
        ISequenceEntityFactory<PostBlock, PostBlockDto> blockFactory)
    {
        _defaultDataService = defaultDataService;
        _translationFactory = translationFactory;
        _blockFactory = blockFactory;
    }

    public async Task<Post> Create(PostDto dto)
    {
        var post = new Post
        {
            Index = await _defaultDataService.GetSequenceNumberOfPost(),
            Translations = new[] {await CreateTranslation(dto)},
            Blocks = await CreateBlocks(dto).ToListAsync(),
            TypeLinks = CreateTypeLinks(dto).ToList(),
        };

        return post;
    }

    private Task<PostTranslation> CreateTranslation(PostDto dto)
    {
        return _translationFactory.Create(dto);
    }

    private async IAsyncEnumerable<PostBlock> CreateBlocks(PostDto dto)
    {
        var sequenceNumber = 0;

        foreach (var blockDto in dto.Blocks)
        {
            yield return await _blockFactory.Create(blockDto, sequenceNumber);
            sequenceNumber++;
        }
    }

    private IEnumerable<PostTypeLink> CreateTypeLinks(PostDto dto)
    {
        return dto.Types.Select(type => new PostTypeLink {Type = type});
    }
}
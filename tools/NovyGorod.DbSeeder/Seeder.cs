using NovyGorod.DbSeeder.DtoParsers;
using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.EntityFactories;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder;

internal class Seeder
{
    private readonly IDtoParser<PostDto> _dtoParser;
    private readonly IEntityFactory<Post, PostDto> _entityFactory;
    private readonly IEntityModificationService<Post> _entityModificationService;
    private readonly ICommitter _committer;

    public Seeder(
        IDtoParser<PostDto> dtoParser,
        IEntityFactory<Post, PostDto> entityFactory,
        IEntityModificationService<Post> entityModificationService,
        ICommitter committer)
    {
        _dtoParser = dtoParser;
        _entityFactory = entityFactory;
        _entityModificationService = entityModificationService;
        _committer = committer;
    }

    public async Task Seed()
    {
        var postDto = _dtoParser.Parse();
        var postEntity = await _entityFactory.Create(postDto);
        await _entityModificationService.Add(postEntity);
        await _committer.Commit();
    }
}
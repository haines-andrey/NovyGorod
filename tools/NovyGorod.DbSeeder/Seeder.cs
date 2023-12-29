using NovyGorod.DbSeeder.DtoParsers;
using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.EntityFactories;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder;

internal class Seeder
{
    private readonly IDtoParser<PostDto> _dtoParser;
    private readonly IEntityFactory<Post, PostDto> _entityFactory;
    private readonly IRepository<Post> _repository;
    private readonly ICommitter _committer;

    public Seeder(
        IDtoParser<PostDto> dtoParser,
        IEntityFactory<Post, PostDto> entityFactory,
        IRepository<Post> repository,
        ICommitter committer)
    {
        _dtoParser = dtoParser;
        _entityFactory = entityFactory;
        _repository = repository;
        _committer = committer;
    }

    public async Task Seed()
    {
        var postDto = _dtoParser.Parse();
        var postEntity = await _entityFactory.Create(postDto);
        await _repository.Add(postEntity);
        await _committer.Commit();
    }
}
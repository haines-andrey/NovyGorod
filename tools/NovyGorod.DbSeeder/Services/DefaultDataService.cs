using Microsoft.Extensions.Configuration;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.Services;

internal class DefaultDataService : IDefaultDataService
{
    private readonly IConfiguration _configuration;
    private readonly IReadOnlyRepository<Post> _repository;

    public DefaultDataService(
        IConfiguration configuration,
        IReadOnlyRepository<Post> repository)
    {
        _configuration = configuration;
        _repository = repository;
    }

    public Task<int> GetLanguageId()
    {
        var langId = int.Parse(_configuration["languageId"]);

        return Task.FromResult(langId);
    }

    public async Task<int> GetSequenceNumberOfPost()
    {
        var query = QueryBuilder<Post>.CreateNew()
            .Order(orderable => orderable.OrderByDesc(post => post.Index))
            .Build();

        var lastNumber = await _repository.GetFirst(query, post => post.Index);

        return ++lastNumber;
    }
}
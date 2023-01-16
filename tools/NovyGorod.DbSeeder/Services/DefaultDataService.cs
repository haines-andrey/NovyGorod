using Microsoft.Extensions.Configuration;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.Services;

internal class DefaultDataService : IDefaultDataService
{
    private readonly IConfiguration _configuration;
    private readonly IEntityAccessService<Post> _postAccessService;

    public DefaultDataService(
        IConfiguration configuration,
        IEntityAccessService<Post> postAccessService)
    {
        _configuration = configuration;
        _postAccessService = postAccessService;
    }

    public Task<int> GetLanguageId()
    {
        return Task.FromResult(int.Parse(_configuration["languageId"]));
    }

    public async Task<int> GetSequenceNumberOfPost()
    {
        var lastNumber = await _postAccessService.GetFirst(new PostQueryParams(), post => post.Index);

        return ++lastNumber;
    }

    private class PostQueryParams : BaseQueryParameters<Post>
    {
        protected override void AddSorting()
        {
            Sort(OrderType.Desc, post => post.Index);
        }
    }
}
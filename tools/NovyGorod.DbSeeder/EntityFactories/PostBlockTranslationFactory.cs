using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.Services;
using NovyGorod.Domain.Models.Common.Translations;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class PostBlockTranslationFactory : IEntityFactory<PostBlockTranslation, PostBlockDto>
{
    private readonly IDefaultDataService _defaultDataService;

    public PostBlockTranslationFactory(IDefaultDataService defaultDataService)
    {
        _defaultDataService = defaultDataService;
    }

    public async Task<PostBlockTranslation> Create(PostBlockDto dto)
    {
        var translation =  new PostBlockTranslation
        {
            Title = dto.Title,
            Text = dto.Text,
            Id = new TranslationOfModelId<int> {LanguageId = await _defaultDataService.GetLanguageId()},
        };

        return translation;
    }
}
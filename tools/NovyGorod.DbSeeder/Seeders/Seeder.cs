using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Infrastructure.DataAccess.EF;

namespace NovyGorod.DbSeeder.Seeders;

public class Seeder : ISeeder
{
    private readonly ICommitter _committer;
    private readonly IEntityModificationService<Post> _entityModificationService;
    private readonly IEntityModificationService<Language> _languageModificationService;

    public Seeder(
        ICommitter committer,
        IEntityModificationService<Post> entityModificationService,
        IEntityModificationService<Language> languageModificationService)
    {
        _committer = committer;
        _entityModificationService = entityModificationService;
        _languageModificationService = languageModificationService;
    }

    public async Task Seed()
    {
        var jPosts = ParseJPosts("seed_projects_posts.json");
        
        var lang = new Language {Code = "ru"};
        await _languageModificationService.Add(lang);
        await _committer.Commit();
        
        var posts = jPosts.GroupBy(x => x.Type).SelectMany(x => x.Select((y, i) => y.Map(i, lang))).ToArray();

        await _entityModificationService.AddRange(posts);
        await _committer.Commit();
    }

    private static IList<JPost> ParseJPosts(string filePath)
    {
        var text = File.ReadAllText(filePath);

        var settings = new JsonSerializerSettings {DateFormatString = "dd.MM.yyyy HH:mm:ss",};
        var jPosts = JsonConvert.DeserializeObject<IList<JPost>>(text, settings);

        return jPosts;
    }
}
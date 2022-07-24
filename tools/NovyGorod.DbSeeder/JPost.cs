using System;
using System.Collections.Generic;
using System.Linq;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder;

public class JPost
{
    public PostType Type { get; set; }
    public DateTime CreationDate { get; set; }
    public string Title { get; set; }
    public string MainImageUrl { get; set; }
    public IList<JBlock> Blocks { get; set; }

    public Post Map(int index, Language lang)
    {
        var post = new Post
        {
            Type = Type,
            Index = index,
            CreatedAt = CreationDate
        };

        var translation = new PostTranslation
        {
            Entity = post,
            Language = lang,
            Title = Title
        };

        post.Blocks = Blocks.Select((x, i) => x.Map(i, lang, post)).ToArray();

        var preview = new MediaData
        {
            Type = MediaDataType.Image,
            IsLocal = false,
            Url = MainImageUrl,
        };

        translation.Preview = preview;
        post.Translations = new List<PostTranslation> {translation};

        return post;
    }
}
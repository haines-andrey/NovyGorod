using System.Collections.Generic;
using System.Linq;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder;

public class JBlock
{
    public string Title { get; set; }
    public string Text { get; set; }
    public IList<JAttachment> Attachments { get; set; }

    public PostBlock Map(int index, Language lang, Post post)
    {
        var block = new PostBlock {Post = post, Index = index};

        var translation = new PostBlockTranslation {Language = lang, Entity = block, Title = Title, Text = Text};

        block.Translations = new List<PostBlockTranslation> {translation};
        block.Attachments = Attachments.Select((x, i) => x.Map(i, lang, block)).ToList();
            
        return block;
    }
}
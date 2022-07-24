using System.Collections.Generic;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder;

public class JAttachment
{
    public MediaDataType Type { get; set; }
    public string Url { get; set; }

    public Attachment Map(int index, Language lang, PostBlock block)
    {
        var attachment = new Attachment {Block = block, Index = index};

        var translation = new AttachmentTranslation {Language = lang, Entity = attachment};

        var mediaData = new MediaData
        {
            IsLocal = false,
            Type = Type,
            Url = Url,
        };

        translation.Media = mediaData;

        attachment.Translations = new List<AttachmentTranslation> {translation};

        return attachment;
    }
}
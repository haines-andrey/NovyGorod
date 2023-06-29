using NovyGorod.Application.Contracts.Media.Dto;
using NovyGorodAsp.Models.Posts.MediaData.Settings;

namespace NovyGorodAsp.Models.Posts.MediaData;

public class MediaDataViewModel
{
    public MediaDataDto MediaData { get; set; }

    public ImageSettings ImageSettings { get; set; }

    public VideoSettings VideoSettings { get; set; }
}
namespace NovyGorodAsp.Models.Posts.MediaData.Settings;

public class VideoSettings : BaseSettings<VideoSettings>
{
    public override VideoSettings WithDefaultRatio() => AppendClassString("ratio ratio-16x9");
}
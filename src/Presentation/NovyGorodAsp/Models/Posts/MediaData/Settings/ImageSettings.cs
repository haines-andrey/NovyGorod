namespace NovyGorodAsp.Models.Posts.MediaData.Settings;

public class ImageSettings : BaseSettings<ImageSettings>
{
    public string ParentClassString { get; set; }
    
    public ImageSettings WithFluid() => AppendClassString("img-fluid");

    public ImageSettings WithCentering() => AppendParentClassString("d-flex")
        .AppendClassString("mx-auto");

    public override ImageSettings WithDefaultRatio() => AppendParentClassString("ratio ratio-16x9");

    private ImageSettings AppendParentClassString(string value)
    {
        ParentClassString += $"{value} ";

        return this;
    }
}
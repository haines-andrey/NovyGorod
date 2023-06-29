namespace NovyGorodAsp.Models.Posts.MediaData.Settings;

public abstract class BaseSettings<TSettings>
    where TSettings : BaseSettings<TSettings>
{
    public string ClassString { get; set; } = string.Empty;

    protected TSettings AppendClassString(string value)
    {
        ClassString += $"{value} ";

        return (TSettings)this;
    }

    public virtual TSettings WithShadow() => AppendClassString("shadow");

    public virtual TSettings WithNonSelectable() => AppendClassString("user-select-none");

    public abstract TSettings WithDefaultRatio();
}
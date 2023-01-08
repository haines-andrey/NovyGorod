using NovyGorod.Common.Exceptions;

namespace NovyGorodAsp.Models.Error;

public class ErrorViewModel
{
    public ErrorCode Code { get; init; }

    public virtual string EmojiPath => "/images/emoji/fearful_face_3d.png";

    public virtual string Title => "Что-то&nbsp;пошло&nbsp;не&nbsp;так";

    public virtual string SecondaryText => "Повторите&nbsp;попытку&nbsp;позже";
}
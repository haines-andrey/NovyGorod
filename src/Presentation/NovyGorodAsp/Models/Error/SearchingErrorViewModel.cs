namespace NovyGorodAsp.Models.Error;

public class SearchingErrorViewModel : ErrorViewModel
{
    public override string EmojiPath => "/images/emoji/magnifying_glass_tilted_right_3d.png";

    public override string Title => "Такой&nbsp;страницы не&nbsp;существует";

    public override string SecondaryText => "Возможно, вы&nbsp;перешли&nbsp;по неправильному&nbsp;адресу";
}
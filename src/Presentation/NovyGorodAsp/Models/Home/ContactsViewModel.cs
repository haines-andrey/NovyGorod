namespace NovyGorodAsp.Models.Home;

public class ContactsViewModel
{
    public ContactViewModel Phone { get; } = new()
    {
        Url = "tel:+375(29)652-31-52",
        Title = "Телефон",
        Info = "+375 (29) 652-31-52",
        IconName = "bi-phone"
    };

    public ContactViewModel Mail { get; } = new()
    {
        Url = "mailto:lud.konopl.work@gmail.com",
        Title = "Почта",
        Info = "lud.konopl.work@gmail.com",
        IconName = "bi-envelope"
    };

    public ContactViewModel Office { get; } = new()
    {
        Url = "https://yandex.ru/maps?pt=27.604851,53.917506&z=16&l=map",
        Title = "Офис",
        Info = "г.&nbsp;Минск, ул.&nbsp;Сурганова, д.&nbsp;2, оф.&nbsp;32",
        IconName = "bi-geo-alt",
        OpenLinkInNewPage = true,
    };

    public ContactViewModel Instagram { get; } = new()
    {
        Url = "tel:+375(29)652-31-52",
        Title = "Инстаграм",
        Info = "@novygorod.by",
        IconName = "bi-instagram",
        OpenLinkInNewPage = true,
    };
}
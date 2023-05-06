using NovyGorod.Domain.Models;

namespace NovyGorod.DbSeeder.Dtos;

internal class MediaDataDto
{
    public MediaDataType Type { get; set; }

    public string Url { get; set; }

    public bool IsLocal { get; set; }
}
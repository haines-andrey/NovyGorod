using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.Dtos;

internal class PostDto
{
    public string CreatedAt { get; set; }

    public string Title { get; set; }

    public string Summary { get; set; }

    public string PreviewImageFilePath { get; set; }

    public string VideoUrl { get; set; }

    public List<PostType> Types { get; set; }

    public List<PostBlockDto> Blocks { get; set; }
}
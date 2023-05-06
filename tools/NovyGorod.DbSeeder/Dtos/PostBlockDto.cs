namespace NovyGorod.DbSeeder.Dtos;

internal class PostBlockDto
{
    public string Title { get; set; }
    
    public string Text { get; set; }

    public List<AttachmentDto> Attachments { get; set; }
}
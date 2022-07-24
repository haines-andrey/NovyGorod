using System.Collections.Generic;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorodAsp.Models.Posts;

public class PostViewModel
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public MediaData Preview { get; set; }
    public List<PostBlock> Type { get; set; }
}
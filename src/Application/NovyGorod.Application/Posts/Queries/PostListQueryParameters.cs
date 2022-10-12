using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Builders;
using NovyGorod.Domain.EntityAccess.Queries.Results;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Posts.Queries;

public class PostListQueryParameters : TranslatedEntityQueryParameters<Post, PostTranslation>
{
    public PostType? Type { get; set; }

    public int Count { get; set; }

    protected override void AddFilters()
    {
        base.AddFilters();
        FilterIf(Type.HasValue, post => post.Type == Type);
    }

    protected override void AddSorting()
    {
        base.AddSorting();
        Sort(OrderType.Desc, post => post.Index);
    }

    protected override void AddPaging()
    {
        Paging(new Paging(0, Count));
    }
}
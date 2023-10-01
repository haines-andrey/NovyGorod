using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.Models.Posts;
using PostModel = NovyGorod.Domain.Models.Posts.Post;

namespace NovyGorod.Domain.ModelAccess.Filters;

public static class Post
{
    public static QueryFilter<PostModel> IdIs(int id) => Common.IdIs<PostModel>(id);

    public static QueryFilter<PostModel> IdIsIn(IEnumerable<int> ids) => Common.IdIsIn<PostModel>(ids);

    public static QueryFilter<PostModel> IsTranslatedInto(int languageId) =>
        Common.IsTranslatedInto<PostModel, int, PostTranslation>(languageId);
    
    public static QueryFilter<PostModel> IsTranslatedInto(IEnumerable<int> languageIds) =>
        Common.IsTranslatedInto<PostModel, int, PostTranslation>(languageIds);

    public static QueryFilter<PostModel> TypeIs(PostType type) =>
        Create(post => post.TypeLinks.Any(link => link.Type == type));

    public static QueryFilter<PostModel> TypeIsIn(IEnumerable<PostType> types)
    {
        var typesList = types.Distinct().ToList();

        return Create(post => post.TypeLinks.Any(link => typesList.Contains(link.Type)));
    }

    private static QueryFilter<PostModel> Create(Expression<Func<PostModel, bool>> expression) =>
        QueryFilter<PostModel>.Create(expression);
}
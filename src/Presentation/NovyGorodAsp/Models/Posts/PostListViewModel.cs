using NovyGorod.Application.Contracts.Common.Paginate;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Domain.Models.Posts;
using NovyGorodAsp.Models.Shared;

namespace NovyGorodAsp.Models.Posts;

public class PostsListViewModel
{
    public PostType Type { get; init; }

    public ModelsPaginationDto<PostListDto> ModelsPaginationResult { get; init; }

    public string ControllerActionName { get; init; }

    public PostListPaginationViewModel PaginationViewModel => new()
    {
        Type = Type,
        Paging = ModelsPaginationResult.Paging,
        ControllerActionName = ControllerActionName,
    };

    public PostListContainerViewModel ContainerViewModel => new() {Posts = ModelsPaginationResult.Items};
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Posts;

public class GetPostRequestHandler : IRequestHandler<GetPostRequest, PostDto>
{
    private readonly IReadOnlyRepository<Post> _repository;
    private readonly IMapper _mapper;

    public GetPostRequestHandler(
        IReadOnlyRepository<Post> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PostDto> Handle(GetPostRequest request, CancellationToken cancellationToken)
    {
        var query = QueryBuilder<Post>
            .CreateWithFilter(
                Filters.Post.IdIs(request.Id) &
                Filters.Post.IsTranslatedInto(request.LanguageId))
            .Include(includable =>
                includable.IncludeMany(post => post.Translations
                    .Where(translation => translation.Id.LanguageId == request.LanguageId)))
            .Build();

        var post = await _repository.GetSingle(query, cancellationToken);

        return _mapper.MapWithTranslation<PostDto>(post, request.LanguageId);
    }
}
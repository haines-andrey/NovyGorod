using AutoMapper;
using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.ModelAccess.Queries.Results;

namespace NovyGorod.Application.Common.Search;

public class SearchResultMappingProfile : Profile
{
    public SearchResultMappingProfile()
    {
        CreateMap<Paging, PagingResultDto>();
    }
}
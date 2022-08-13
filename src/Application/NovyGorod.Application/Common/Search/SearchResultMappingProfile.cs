using AutoMapper;
using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Application.Common.Search;

public class SearchResultMappingProfile : Profile
{
    public SearchResultMappingProfile()
    {
        CreateMap<PagingResult, PagingDto>();
    }
}
using AutoMapper;
using NovyGorod.Application.Contracts.Common.Paginate;
using NovyGorod.Domain.ModelAccess.Queries.Results;

namespace NovyGorod.Application.Common.Paginate;

public class PagingMappingProfile : Profile
{
    public PagingMappingProfile()
    {
        CreateMap<Paging, PagingDto>();
    }
}
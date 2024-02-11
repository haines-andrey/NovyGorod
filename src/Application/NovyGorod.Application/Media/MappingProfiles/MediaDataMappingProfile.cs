using AutoMapper;
using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Dto;
using NovyGorod.Application.Contracts.Media.Requests;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Media.MappingProfiles;

public class MediaDataMappingProfile : Profile
{
    public MediaDataMappingProfile(IExecutionContextAccessor executionContextAccessor)
    {
        CreateMap<MediaData, MediaDataDto>()
            .ForMember(x => x.Url,
                opt => opt.MapFrom(media =>
                    media.IsLocal
                        ? $"{executionContextAccessor.GetCurrentUrl()}/mediadata/{media.Id}"
                        : media.Url));

        CreateMap<CreateExternalMediaDataRequest, MediaData>()
            .ForMember(x => x.IsLocal, opt => opt.Ignore());
    }
}
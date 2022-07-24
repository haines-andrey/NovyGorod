using AutoMapper;
using NovyGorod.Application.Contracts.Attachments.Dto;
using NovyGorod.Domain.Models.Attachments;

namespace NovyGorod.Application.Attachments.MappingProfiles;

public class AttachmentMappingProfile : Profile
{
    public AttachmentMappingProfile()
    {
        CreateMap<Attachment, AttachmentDto>()
            .FindTranslationBeforeMap()
            .ForMemberMapFromTranslation(dto => dto.Summary, translation => translation.Summary)
            .ForMemberMapFromTranslation(dto => dto.Media, translation => translation.Media);
    }
}
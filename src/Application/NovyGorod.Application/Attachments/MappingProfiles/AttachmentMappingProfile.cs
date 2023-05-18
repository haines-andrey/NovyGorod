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
            .ForMemberMapFromTranslation(dto => dto.PreviewMedia, translation => translation.PreviewMedia)
            .ForMemberMapFromTranslation(dto => dto.SourceMedia, translation => translation.SourceMedia);
    }
}
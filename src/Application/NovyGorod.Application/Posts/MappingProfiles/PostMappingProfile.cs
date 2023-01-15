using System.Linq;
using AutoMapper;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Posts.MappingProfiles.Extensions;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Posts.MappingProfiles;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<Post, PostDto>()
            .ForMember(dto => dto.Types, opt => opt.MapFrom(entity => entity.TypeLinks.Select(link => link.Type)))
            .FindTranslationBeforeMap()
            .ForMemberMapFromTranslation(dto => dto.Title, translation => translation.Title)
            .ForMemberMapFromTranslation(dto => dto.Summary, translation => translation.Summary)
            .ForMemberMapFromTranslation(dto => dto.Preview, translation => translation.Preview)
            .ForMemberMapFromTranslation(dto => dto.Video, translation => translation.Video);

        CreateMap<Post, PostListDto>()
            .ForMember(dto => dto.Types, opt => opt.MapFrom(entity => entity.TypeLinks.Select(link => link.Type)))
            .FindTranslationBeforeMap()
            .ForMemberMapFromTranslation(dto => dto.Title, translation => translation.Title)
            .ForMemberMapFromTranslation(dto => dto.Summary, translation => translation.Summary)
            .ForMemberMapFromTranslation(dto => dto.Preview, translation => translation.Preview);

        CreateMap<PostBlock, PostBlockDto>()
            .FindTranslationBeforeMap()
            .ForMemberMapFromTranslation(dto => dto.Title, translation => translation.Title)
            .ForMemberMapFromTranslation(dto => dto.Text, translation => translation.Text);
    }
}
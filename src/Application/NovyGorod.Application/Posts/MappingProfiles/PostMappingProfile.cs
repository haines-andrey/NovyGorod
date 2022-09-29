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
            .FindTranslationBeforeMap()
            .ForMemberMapFromTranslation(dto => dto.Title, translation => translation.Title)
            .ForMemberMapFromTranslation(dto => dto.Summary, translation => translation.Summary)
            .ForMemberMapFromTranslation(dto => dto.Preview, translation => translation.Preview)
            .ForMemberMapFromTranslation(dto => dto.Video, translation => translation.Video);

        CreateMap<Post, PostListDto>()
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
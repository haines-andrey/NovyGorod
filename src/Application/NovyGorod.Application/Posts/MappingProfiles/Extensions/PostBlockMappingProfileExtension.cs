using System;
using System.Linq.Expressions;
using AutoMapper;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Posts.MappingProfiles.Extensions;

public static class PostBlockMappingProfileExtension
{
    public static IMappingExpression<PostBlock, TDestination> FindTranslationBeforeMap<TDestination>(
        this IMappingExpression<PostBlock, TDestination> expression)
    {
        return expression.FindTranslationBeforeMap<PostBlock, PostBlockTranslation, TDestination>();
    }

    public static IMappingExpression<PostBlock, TDestination> ForMemberMapFromTranslation<
        TDestination, TMember, TResult>(
        this IMappingExpression<PostBlock, TDestination> expression,
        Expression<Func<TDestination, TMember>> destinationMember,
        Expression<Func<PostBlockTranslation, TResult>> mapFrom)
    {
        return expression
            .ForMemberMapFromTranslation<PostBlock, PostBlockTranslation, TDestination, TMember, TResult>(
                destinationMember,
                mapFrom);
    }
}
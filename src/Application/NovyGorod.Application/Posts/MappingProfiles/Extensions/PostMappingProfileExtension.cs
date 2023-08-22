using System;
using System.Linq.Expressions;
using AutoMapper;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Posts.MappingProfiles.Extensions;

public static class PostMappingProfileExtension
{
    public static IMappingExpression<Post, TDestination> FindTranslationBeforeMap<TDestination>(
        this IMappingExpression<Post, TDestination> expression)
    {
        return expression.FindTranslationBeforeMap<Post, PostTranslation, TDestination>();
    }

    public static IMappingExpression<Post, TDestination> ForMemberMapFromTranslation<TDestination, TMember, TResult>(
        this IMappingExpression<Post, TDestination> expression,
        Expression<Func<TDestination, TMember>> destinationMember,
        Expression<Func<PostTranslation, TResult>> mapFrom)
    {
        return expression.ForMemberMapFromTranslation<Post, PostTranslation, TDestination, TMember, TResult>(
            destinationMember, mapFrom);
        
    }
}
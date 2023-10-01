using System;
using System.Linq.Expressions;
using AutoMapper;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Domain.Models.Attachments;

namespace NovyGorod.Application.Attachments.MappingProfiles;

public static class AttachmentMappingProfileExtension
{
    public static IMappingExpression<Attachment, TDestination> FindTranslationBeforeMap<TDestination>(
        this IMappingExpression<Attachment, TDestination> expression)
    {
        return expression.FindTranslationBeforeMap<Attachment, AttachmentTranslation, TDestination>();
    }

    public static IMappingExpression<Attachment, TDestination> ForMemberMapFromTranslation<
        TDestination, TMember, TResult>(
        this IMappingExpression<Attachment, TDestination> expression,
        Expression<Func<TDestination, TMember>> destinationMember,
        Expression<Func<AttachmentTranslation, TResult>> mapFrom)
    {
        return expression
            .ForMemberMapFromTranslation<Attachment, AttachmentTranslation, TDestination, TMember, TResult>(
                destinationMember, mapFrom);
    }
}
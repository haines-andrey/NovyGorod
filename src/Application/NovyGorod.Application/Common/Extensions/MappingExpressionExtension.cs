using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Application.Common.Extensions;

public static class MappingExpressionExtension
{
    public static IMappingExpression<TSource, TDestination> FindTranslationBeforeMap<
        TSource, TTranslation, TDestination>(
        this IMappingExpression<TSource, TDestination> expression)
        where TSource : BaseModel, ITranslatedModel<TSource, int, TTranslation>
        where TTranslation : TranslationOfBaseModel<TSource>
    {
        return FindTranslationBeforeMap<TSource, int, TTranslation, TDestination>(expression);
    }

    public static IMappingExpression<TSource, TDestination> FindTranslationBeforeMap<
        TSource, TSourceId, TTranslation, TDestination>(
        this IMappingExpression<TSource, TDestination> expression)
        where TSource : IHasId<TSourceId>, ITranslatedModel<TSource, TSourceId, TTranslation>
        where TSourceId : IEquatable<TSourceId>
        where TTranslation : TranslationOfModel<TSource, TSourceId, TranslationOfModelId<TSourceId>>
    {
        return expression.BeforeMap((source, _, context) =>
        {
            if (!context.Items.ContainsKey("languageId"))
            {
                return;
            }
            
            var languageId = (int)context.Items["languageId"];
            var translation = source.Translations
                .SingleOrDefault(translation => translation.Id.LanguageId == languageId);
            context.Items[typeof(TTranslation).Name] = translation;
        });
    }

    public static IMappingExpression<TSource, TDestination> ForMemberMapFromTranslation<
        TSource, TTranslation, TDestination, TMember, TResult>(
        this IMappingExpression<TSource, TDestination> expression,
        Expression<Func<TDestination, TMember>> destinationMember,
        Expression<Func<TTranslation, TResult>> mapFrom)
        where TSource : BaseModel, ITranslatedModel<TSource, int, TTranslation>
        where TTranslation : TranslationOfBaseModel<TSource>
    {
        return ForMemberMapFromTranslation<TSource, int, TTranslation, TDestination, TMember, TResult>(
            expression, destinationMember, mapFrom);
    }

    public static IMappingExpression<TSource, TDestination> ForMemberMapFromTranslation<
        TSource, TSourceId, TTranslation, TDestination, TMember, TResult>(
        this IMappingExpression<TSource, TDestination> expression,
        Expression<Func<TDestination, TMember>> destinationMember,
        Expression<Func<TTranslation, TResult>> mapFrom)
        where TSource : IHasId<TSourceId>, ITranslatedModel<TSource, TSourceId, TTranslation>
        where TSourceId : IEquatable<TSourceId>
        where TTranslation : TranslationOfModel<TSource, TSourceId, TranslationOfModelId<TSourceId>>
    {
        return expression.ForMember(destinationMember, opt => opt.MapFrom((_, _, _, context) =>
        {
            var key = typeof(TTranslation).Name;

            if (!context.Items.ContainsKey(key))
            {
                return default;
            }

            var translation = (TTranslation)context.Items[key];

            return mapFrom.Compile().Invoke(translation);
        }));
    }
}
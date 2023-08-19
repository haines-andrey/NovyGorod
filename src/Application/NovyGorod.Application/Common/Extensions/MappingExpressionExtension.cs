using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Common.Extensions;

public static class MappingExpressionExtension
{
    public static IMappingExpression<TSource, TDestination> FindTranslationBeforeMap<
        TSource, TSourceId, TTranslation, TDestination>(
        this IMappingExpression<TSource, TDestination> expression)
        where TSource : IHasId<TSourceId>, ITranslatedModel<TSource, TSourceId, TTranslation>
        where TTranslation : ITranslationOfModel<TSource, TSourceId>
    {
        return expression.BeforeMap((source, _, context) =>
        {
            if (!context.Items.ContainsKey("languageId"))
            {
                return;
            }
            
            var languageId = (int)context.Items["languageId"];
            var translation = source.Translations.SingleOrDefault(x => x.LanguageId == languageId);
            context.Items[typeof(TTranslation).Name] = translation;
        });
    }

    public static IMappingExpression<TSource, TDestination> ForMemberMapFromTranslation<
        TSource, TSourceId, TTranslation, TDestination, TMember, TResult>(
        this IMappingExpression<TSource, TDestination> expression,
        Expression<Func<TDestination, TMember>> destinationMember,
        Expression<Func<TTranslation, TResult>> mapFrom)
        where TSource : IHasId<TSourceId>, ITranslatedModel<TSource, TSourceId, TTranslation>
        where TTranslation : ITranslationOfModel<TSource, TSourceId>
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
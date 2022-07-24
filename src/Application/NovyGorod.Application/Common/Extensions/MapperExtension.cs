using AutoMapper;

namespace NovyGorod.Application.Common.Extensions;

public static class MapperExtension
{
    public static TDestination MapWithTranslation<TDestination>(
        this IMapper mapper, object source, int languageId)
    {
        return mapper.Map<TDestination>(source, opts => opts.Items.Add("languageId", languageId));
    }
}
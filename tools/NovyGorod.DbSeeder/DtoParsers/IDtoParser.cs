namespace NovyGorod.DbSeeder.DtoParsers;

internal interface IDtoParser<out TDto>
{
    TDto Parse();
}
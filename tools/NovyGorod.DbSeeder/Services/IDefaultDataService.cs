namespace NovyGorod.DbSeeder.Services;

internal interface IDefaultDataService
{
    Task<int> GetLanguageId();

    Task<int> GetSequenceNumberOfPost();
}
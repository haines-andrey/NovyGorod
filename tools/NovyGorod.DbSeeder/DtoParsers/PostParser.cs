using Microsoft.Extensions.Configuration;
using NovyGorod.DbSeeder.Dtos;

namespace NovyGorod.DbSeeder.DtoParsers;

internal class PostParser : BaseDtoParser<PostDto>
{
    public PostParser(IConfiguration configuration) : base(configuration)
    {
    }

    protected override string ConfigFilePathKey => "parsable_post_file_path";
}
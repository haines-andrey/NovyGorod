using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;

namespace NovyGorod.DbSeeder.DtoParsers;

internal abstract class BaseDtoParser<TDto> : IDtoParser<TDto>
{
    private readonly IConfiguration _configuration;

    public BaseDtoParser(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected abstract string ConfigFilePathKey { get; }

    public TDto Parse()
    {
        var filePath = _configuration[ConfigFilePathKey];

        if (filePath is null)
        {
            throw new ArgumentException(
                $"file path is not set in configuration by key '{ConfigFilePathKey}'", nameof(filePath));
        }
        
        var node = JsonNode.Parse(File.ReadAllText(filePath));

        return node.Deserialize<TDto>();
    }
}
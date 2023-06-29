using System;
using System.Reflection;

namespace NovyGorodAsp.Models.Shared;

public class FooterViewModel
{
    public string GetCopyrightString(string companyName)
    {
        return $"{companyName} \u00a9 {DateTime.Today.Year}";
    }
    
    public string GetApplicationVersionString()
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;

        return version is not null ? $"v{version.Major}.{version.Minor}" : null;
    }
}
using System;

namespace NovyGorodAsp.Models.Shared;

public class FooterViewModel
{
    public string GetCopyrightString(string companyName)
    {
        return $"{companyName} \u00a9 {DateTime.Today.Year}";
    }
}
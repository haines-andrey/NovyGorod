using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NovyGorod.Common.Exceptions;
using NovyGorod.Infrastructure.DataAccess.EF;
using NovyGorodAsp.Middlewares;
using Serilog;

namespace NovyGorodAsp;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }

    public IConfiguration Configuration { get; }
        
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews()
            .AddViewLocalization(opt => opt.ResourcesPath = "Resources");
        services.AddHttpContextAccessor();
        services.AddRouting(opt =>
        {
            opt.LowercaseUrls = true;
            opt.LowercaseQueryStrings = true;
        });
        services.AddCors(opt => opt.AddDefaultPolicy(builder => builder
            .AllowAnyOrigin()));
        
        services.AddTransient<ExceptionHandlingMiddleware>();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.AddDataAccessEf<Context>();
        builder.RegisterModule<NovyGorod.Application.Module>();
        builder.RegisterModule<Module>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
            
        var supportedCultures = new[] {new CultureInfo("ru")};
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("ru"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures,
            ApplyCurrentCultureToResponseHeaders = true,
            RequestCultureProviders = new List<IRequestCultureProvider>{new RouteDataRequestCultureProvider()}
        });

        app.UseCors();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "",
                defaults: new { controller = "Home", action = "Index" });
        });
        
        app.UseStatusCodePages(new StatusCodePagesOptions
        {
            HandleAsync = ctx =>
            {
                if (ctx.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    throw new CodedException(ErrorCode.RouteNotFound);
                }

                return Task.CompletedTask;
            }
        });
    }
}
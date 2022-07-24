using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace NovyGorod.Application;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAutoMapper(ThisAssembly);
        builder.RegisterMediatR(ThisAssembly);
    }
}
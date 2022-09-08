using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Rules;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace Kodlama.io.Devs.Application;
public static class ApplicationServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
     
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<ProgrammingFrameworkBusinessRules>();

        return services;
    }
}
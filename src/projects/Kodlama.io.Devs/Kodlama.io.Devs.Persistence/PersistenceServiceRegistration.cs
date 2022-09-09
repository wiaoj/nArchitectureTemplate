using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Persistence.Context;
using Kodlama.io.Devs.Persistence.Repositories.ReadRepositories;
using Kodlama.io.Devs.Persistence.Repositories.WriteRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence;
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<BaseDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("KodlamaIoDevsConnectionString")));

        services.AddScoped<IProgrammingLanguageReadRepository, ProgrammingLanguageReadRepository>();
        services.AddScoped<IProgrammingLanguageWriteRepository, ProgrammingLanguageWriteRepository>();

        services.AddScoped<IProgrammingFrameworkReadRepository, ProgrammingFrameworkReadRepository>();
        services.AddScoped<IProgrammingFrameworkWriteRepository, ProgrammingFrameworkWriteRepository>();

        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();

        services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();
        services.AddScoped<IRefreshTokenWriteRepository, RefreshTokenWriteRepository>();

        services.AddScoped<IOperationClaimReadRepository, OperationClaimReadRepository>();
        services.AddScoped<IOperationClaimWriteRepository, OperationClaimWriteRepository>();

        services.AddScoped<IUserOperationClaimReadRepository, UserOperationClaimReadRepository>();
        services.AddScoped<IUserOperationClaimWriteRepository, UserOperationClaimWriteRepository>();

        return services;
    }
}
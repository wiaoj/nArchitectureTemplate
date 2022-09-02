using Kodlama.io.Devs.Application.Services.ReadRepositories;
using Kodlama.io.Devs.Application.Services.WriteRepositories;
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

        return services;
    }
}
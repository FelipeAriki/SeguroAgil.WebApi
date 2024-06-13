using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SeguroAgil.Application.Interfaces;
using SeguroAgil.Application.Services;
using SeguroAgil.Domain.Entities;
using SeguroAgil.Domain.Interfaces;
using SeguroAgil.Infra.Data.Repositories;

namespace SeguroAgil.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            builder.Services.Configure<ClientDatabaseSettings>(builder.Configuration.GetSection(nameof(ClientDatabaseSettings)));

            builder.Services.AddSingleton<IClientDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ClientDatabaseSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ClientDatabaseSettings:ConnectionString")));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();


            return services;
        }
    }
}

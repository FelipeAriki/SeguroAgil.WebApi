using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using SeguroAgil.Application.Interfaces;
using SeguroAgil.Application.Services;
using SeguroAgil.Domain.Entities;
using SeguroAgil.Domain.Interfaces;
using SeguroAgil.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<ClientDatabaseSettings>(builder.Configuration.GetSection(nameof(ClientDatabaseSettings)));

builder.Services.AddSingleton<IClientDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ClientDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ClientDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API para Gestão de Clientes", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente API v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

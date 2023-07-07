using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SeguroAgil.Interfaces;
using SeguroAgil.Models;
using SeguroAgil.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<ClientDatabaseSettings>(builder.Configuration.GetSection(nameof(ClientDatabaseSettings)));

builder.Services.AddSingleton<IClientDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ClientDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ClientDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

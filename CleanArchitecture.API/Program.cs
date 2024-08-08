using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddApplicationServices()
                .AddPersistenceServices(builder.Configuration)
                .AddInfraServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication()
   .UseAuthorization();

app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();

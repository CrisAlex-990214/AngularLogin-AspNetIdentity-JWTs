using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddApplicationServices()
                .AddPersistenceServices(builder.Configuration)
                .AddInfraServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication()
   .UseAuthorization();

app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapPost("login", async ([FromBody] LoginRequest loginRequest, IMediator mediator) => await mediator.Send(loginRequest));
app.MapGet("home", () => "Sign-in was successful!").RequireAuthorization();

app.Run();

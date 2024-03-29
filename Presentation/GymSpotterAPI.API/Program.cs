using GymSpotterAPI.Persistence;
using GymSpotterAPI.Domain;
using GymSpotterAPI.Domain.Entities.Identity;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using GymSpotterAPI.Application.Commands.AppUser.CreateUser;
using GymSpotterAPI.API.Controllers;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using GymSpotterAPI.Persistence.Contexts;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GymSpotterAPI.Application.Commands.AppUser.LoginUser;
using GymSpotterAPI.Application.Abstractions.Token;
using System.Configuration;
using GymSpotterAPI.Application;
using GymSpotterAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GymSpotterAPI.Application.Commands.AppUser.OutLoginUser;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Exchange.WebServices.Data;
using FluentValidation.AspNetCore;
using GymSpotterAPI.Application.Validators.AppUsers;
using GymSpotterAPI.Application.Features.CQRS.Handlers.WorkOutHandlers;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GymSpotterAPI", Version = "v1" });

    // ...

    // Add JWT filter for Swagger
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());



builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CreateUserCommandHandler>();

builder.Services.AddTransient<IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>, LoginUserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<OutLoginUserCommandRequest, OutLoginUserCommandResponse>, OutLoginUserCommandHandler>();



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddTransient<GetWorkOutQueryHandler>();
builder.Services.AddTransient<GetWorkOutByIdQueryHandler>();




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
        };
    });


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

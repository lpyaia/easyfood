using Easyfood.Partners.Application;
using Easyfood.Partners.Infrastructure.IoC;
using Easyfood.Partners.Infrastructure.Persistence.EF;
using Easyfood.Partners.Infrastructure.Persistence.EF.Seeds;
using Easyfood.Shared.Authorization.Requirements;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NetDevPack.Identity.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddMediatr();
builder.Services.AddValidatorsFromAssemblyContaining<ApplicationAssembly>();
builder.Services.AddPipelineBehaviors();
builder.Services.AddAutoMapper();
builder.Services.AddCache();
builder.Services.AddDependencies();
builder.Services.AddJwtConfiguration(builder.Configuration, "JwtSettings");
builder.Services.AddAuthorizationRequirement();
builder.Services.AddAuthorization
(
    cfg =>
    {
        cfg.AddPolicy("OnlyAdmin", policy =>
        {
            policy.RequireRole("Admin");
        });

        cfg.AddPolicy("OnlySuperAdmin", policy =>
        {
            policy.RequireClaim("isSuperAdmin");
        });

        cfg.AddPolicy("SeasonedWorker", policy =>
        {
            policy.AddRequirements(new SeasonedWorkerRequirement());
        });
    }
);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EasyFood Parners API",
        Description = "EasyFood Parners API",
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var serviceProvider = serviceScope.ServiceProvider;

    var context = serviceProvider.GetRequiredService<PartnersDbContext>();
    await DataSeed.Seed(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddCustomExceptionMiddleware();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
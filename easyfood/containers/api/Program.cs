using Easyfood.Application;
using Easyfood.Infrastructure.IoC;
using Easyfood.Infrastructure.Persistence.EF;
using Easyfood.Infrastructure.Persistence.EF.Seeds;
using Easyfood.Shared.Authorization.Requirements;
using FluentValidation;
using NetDevPack.Identity.Jwt;

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
builder.Services.AddSwagger();
builder.Services.AddRepositories();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p =>
    {
        p.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

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

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var serviceProvider = serviceScope.ServiceProvider;

    var context = serviceProvider.GetRequiredService<EasyfoodDbContext>();
    await DataSeed.Seed(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.AddCustomExceptionMiddleware();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
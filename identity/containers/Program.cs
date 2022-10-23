using Easyfood.Identity.Data;
using Easyfood.Identity.Models;
using Easyfood.Shared.Authorization.Roles;
using Easyfood.Shared.Common.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MiniValidation;
using NetDevPack.Identity.Interfaces;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p =>
    {
        p.WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Identity API",
        Description = "Identity API.",
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

builder.Services.AddDbContext<EfContext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentityEntityFrameworkContextConfiguration(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//    b => b.MigrationsAssembly("Easyfood.Identity")));

builder.Services.AddIdentityEntityFrameworkContextConfiguration(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityConfiguration();
builder.Services.AddMemoryCache();
builder.Services.AddAuthorization();

builder.Services
    .AddJwtConfiguration(builder.Configuration, "JwtSettings")
    .AddNetDevPackIdentity<IdentityUser>();

#endregion Configure Services

#region Configure Pipeline

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthConfiguration();

MapActions(app);
await SeedData(app);

app.Run();

#endregion Configure Pipeline

#region Actions

static void MapActions(WebApplication app)
{
    app.MapPost("/api/register", [AllowAnonymous] async (
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager,
    IOptions<AppJwtSettings> appJwtSettings,
    IJwtBuilder builder,
    UserRegisterDto registerUser) =>
    {
        if (registerUser == null)
            return Results.BadRequest(new ErrorResponse("Invalid user", "Invalid user.", "Invalid user.", "/api/register", ""));

        if (!MiniValidator.TryValidate(registerUser, out var errors))
            return Results.ValidationProblem(errors);

        var emailIsAlreadyUsed = await userManager.FindByEmailAsync(registerUser.Email) != null;

        if (emailIsAlreadyUsed)
            return Results.BadRequest(new ErrorResponse("Email already in use", $"The email '{registerUser.Email}' is already taken.", "Invalid user.", "/api/register", ""));

        var user = new IdentityUser
        {
            UserName = registerUser.UserName,
            Email = registerUser.Email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, registerUser.Password);

        if (!result.Succeeded)
        {
            string errorDescription = string.Join(',', result.Errors.Select(e => e.Description));
            return Results.BadRequest(new ErrorResponse("Error", errorDescription, errorDescription, "/api/register", ""));
        }

        await userManager.AddClaimAsync(user, new Claim("email", user.Email));
        await userManager.AddClaimAsync(user, new Claim("role", Role.Customer.ToString()));

        UserResponse jwt = await builder
                                    .WithUserId(user.Id)
                                    .WithUsername(user.UserName)
                                    .WithEmail(user.Email)
                                    .WithJwtClaims()
                                    .WithUserClaims()
                                    .WithUserRoles()
                                    .WithRefreshToken()
                                    .BuildUserResponse();

        var response = new ResponseData<UserResponse>(jwt);

        return Results.Ok(response);
    })
    .ProducesValidationProblem()
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .WithName("UserRegister")
    .WithTags("User");

    app.MapPost("/api/login", [AllowAnonymous] async (
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IOptions<AppJwtSettings> appJwtSettings,
        IJwtBuilder builder,
        UserLoginDto loginUser) =>
    {
        if (loginUser == null)
            return Results.BadRequest(new ErrorResponse("Invalid user", "/api/login", ""));

        if (!MiniValidator.TryValidate(loginUser, out var errors))
            return Results.ValidationProblem(errors);

        var result = await signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);

        if (result.IsLockedOut)
            return Results.BadRequest(new ErrorResponse("Blocked User", "/api/login", ""));

        if (!result.Succeeded)
            return Results.BadRequest(new ErrorResponse("Invalid account and/or password", "Your account or password is incorrect.", "Your account or password is incorrect.", "/api/login", ""));

        var user = await userManager.FindByNameAsync(loginUser.UserName);

        UserResponse jwt = await builder
                                    .WithUserId(user.Id)
                                    .WithUsername(user.UserName)
                                    .WithEmail(user.Email)
                                    .WithJwtClaims()
                                    .WithUserClaims()
                                    .WithUserRoles()
                                    .WithRefreshToken()
                                    .BuildUserResponse();

        var response = new ResponseData<UserResponse>(jwt);

        return Results.Ok(response);
    })
    .ProducesValidationProblem()
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .WithName("UserLogin")
    .WithTags("User");
}

static async Task SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory?.CreateScope())
    {
        var userManager = scope?.ServiceProvider?.GetService<UserManager<IdentityUser>>();

        if (userManager != null)
        {
            if (!userManager.Users.Any())
            {
                var admin = new IdentityUser
                {
                    Id = "dbcc2b99-09df-4110-90d8-fbe42f21b1a1",
                    UserName = "admin",
                    Email = "admin@easyfood.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddClaimsAsync(admin, new List<Claim>
                {
                    new Claim("email", admin.Email),
                    new Claim("role", Role.Admin.ToString()),
                    new Claim("employeeSince", "2010-01-01")
                });

                var superAdmin = new IdentityUser
                {
                    Id = "189d257a-045e-4004-bc68-5fab4daf6ded",
                    UserName = "superadmin",
                    Email = "sadmin@easyfood.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(superAdmin, "Sadmin@123");
                await userManager.AddClaimsAsync(superAdmin, new List<Claim>
                {
                    new Claim("email", admin.Email),
                    new Claim("role", Role.Admin.ToString()),
                    new Claim("isSuperAdmin", "true"),
                    new Claim("employeeSince", "2020-10-03")
                });

                var user = new IdentityUser
                {
                    Id = "483692e9-2af6-4fb9-9af6-3d562cdde43e",
                    UserName = "john.doe",
                    Email = "john.doe@easyfood.com",
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(user, "John@123");
                await userManager.AddClaimsAsync(user, new List<Claim>
                {
                    new Claim("email", user.Email),
                    new Claim("role", Role.Customer.ToString()),
                    new Claim("birthDate", "2000-10-03")
                });
            }
        }
    }
}

#endregion Actions
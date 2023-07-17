using Core.Helpers;
using Core.Interfaces;
using Core.Services;
using Infastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Core.Entities.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("RemoteDatabaseConnection")));

builder.Services.AddIdentity<UserEntity, RoleEntity>(options =>
{
    options.Stores.MaxLengthForKeys = 128;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

// Create the symmetric security key for JWT authentication
var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<String>("JWTSecretKey")));

// Configure authentication services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = signinKey,
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Register the generic repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AppMapProfile));

// Register services
builder.Services.AddScoped<JwtTokenServices>();
builder.Services.AddScoped<AlbumServices>();
builder.Services.AddScoped<GenreServices>();
builder.Services.AddScoped<PlaylistServices>();
builder.Services.AddScoped<PublisherServices>();
builder.Services.AddScoped<TrackServices>();

builder.Services.AddScoped<IAccountUserServices, AccountUserServices>();
builder.Services.AddScoped<IJwtTokenServices, JwtTokenServices>();
builder.Services.AddScoped<IAlbumServices, AlbumServices>();
builder.Services.AddScoped<IGenreServices, GenreServices>();
builder.Services.AddScoped<IPlaylistServices, PlaylistServices>();
builder.Services.AddScoped<IPublisherServices, PublisherServices>();
builder.Services.AddScoped<ITrackServices, TrackServices>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(Environment.CurrentDirectory, $"{assemblyName}.xml"));
    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer"
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var imagesStorage = Path.Combine(Directory.GetCurrentDirectory(), "images");
if (!Directory.Exists(imagesStorage)) { Directory.CreateDirectory(imagesStorage); }
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesStorage),
    RequestPath = "/images"
});

var tracksStorage = Path.Combine(Directory.GetCurrentDirectory(), "tracks");
if (!Directory.Exists(tracksStorage)) { Directory.CreateDirectory(tracksStorage); }
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(tracksStorage),
    RequestPath = "/tracks"
});

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.SeedDataAsync();
app.Run();
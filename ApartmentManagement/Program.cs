using ApartmentApplication.Interfaces;
using ApartmentApplication.Interfaces_Service;
using ApartmentApplication.Mapping;
using ApartmentApplication.Services;
using ApartmentDomain.Interfaces;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using ApartmentInfrastructure.Repositories;
using ApartmentInfrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// Controllers
// --------------------------------------------------

builder.Services.AddControllers();

// --------------------------------------------------
// OpenAPI
// --------------------------------------------------

builder.Services.AddOpenApi();

// --------------------------------------------------
// Database
// --------------------------------------------------

builder.Services.AddDbContext<ApartmentDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "ApartmentCS"));
});

// --------------------------------------------------
// AutoMapper
// --------------------------------------------------

// --------------------------------------------------
// AutoMapper
// --------------------------------------------------

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(MappingProfile).Assembly);

// --------------------------------------------------
// Application Services
// --------------------------------------------------

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IBuildingService, BuildingService>();

builder.Services.AddScoped<INoticeService, NoticeService>();

builder.Services.AddScoped<IDocumentService, DocumentService>();

// --------------------------------------------------
// Repository Services
// --------------------------------------------------

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<
    IBuildingRepository,
    BuildingRepository>();

builder.Services.AddScoped<
    INoticeRepository,
    NoticeRepository>();

builder.Services.AddScoped<
    IDocumentRepository,
    DocumentRepository>();

// --------------------------------------------------
// JWT Service
// --------------------------------------------------

builder.Services.AddScoped<IJwtService, JwtService>();

// --------------------------------------------------
// JWT Authentication
// --------------------------------------------------

var jwtKey =
    builder.Configuration["Jwt:Key"];

if (string.IsNullOrWhiteSpace(jwtKey))

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtKey)),

                ValidateIssuer = false,

                ValidateAudience = false,

                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };
    });

// --------------------------------------------------
// Authorization
// --------------------------------------------------

builder.Services.AddAuthorization();

// --------------------------------------------------
// CORS - Angular
// --------------------------------------------------

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

            //Repository

            builder.Services.AddScoped<IFlatRepository, FlatRepository>();
            builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
            builder.Services.AddScoped<IStaffRepository, StaffRepository>();

            //Services

            builder.Services.AddScoped<IFlatService, FlatService>();
            builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();
            builder.Services.AddScoped<IParkingService, ParkingService>();
            builder.Services.AddScoped<IStaffService, StaffService>();

            //AutoMapper

            builder.Services.AddAutoMapper(p => { p.AddProfile<MappingProfile>(); });


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

var app = builder.Build();

// --------------------------------------------------
// OpenAPI
// --------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// --------------------------------------------------
// Middleware
// --------------------------------------------------

app.UseHttpsRedirection();

            app.UseCors(p => p
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();

// --------------------------------------------------
// Controllers
// --------------------------------------------------

app.MapControllers();

app.Run();
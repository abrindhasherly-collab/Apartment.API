using ApartmentApplication.Interfaces;
using ApartmentApplication.Interfaces_Service;
using ApartmentApplication.Mapping;
using ApartmentApplication.Services;

using ApartmentDomain.Interfaces;
using ApartmentDomain.Interfaces_Repository;

using ApartmentInfrastructure.Data;
using ApartmentInfrastructure.Repositories;
using ApartmentInfrastructure.Services;

using ApartmentManagement.Application.Interfaces.Services;
using ApartmentManagement.Application.Services;
using ApartmentManagement.Infrastructure.Repositories;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ==================================================
// Services
// ==================================================

// Controllers
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

// OpenAPI
builder.Services.AddOpenApi();

// ==================================================
// Database
// ==================================================

builder.Services.AddDbContext<ApartmentDbcontext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ApartmentCS"));
});

// ==================================================
// AutoMapper
// ==================================================

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(MappingProfile).Assembly);

// ==================================================
// Authentication - JWT
// ==================================================

var jwtKey = builder.Configuration["Jwt:Key"];

if (string.IsNullOrWhiteSpace(jwtKey))
{
    throw new InvalidOperationException(
        "JWT Key is not configured. Please add 'Jwt:Key' to appsettings.json.");
}

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

// ==================================================
// Authorization
// ==================================================

builder.Services.AddAuthorization();

// ==================================================
// Application Services
// ==================================================

// Authentication
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();

// User
builder.Services.AddScoped<IUserService, UserService>();

// Building
builder.Services.AddScoped<IBuildingService, BuildingService>();

// Notice
builder.Services.AddScoped<INoticeService, NoticeService>();

// Document
builder.Services.AddScoped<IDocumentService, DocumentService>();

// Flat
builder.Services.AddScoped<IFlatService, FlatService>();

// Maintenance
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();

// Parking
builder.Services.AddScoped<IParkingService, ParkingService>();

// Staff
builder.Services.AddScoped<IStaffService, StaffService>();

// Visitor
builder.Services.AddScoped<IVisitorService, VisitorService>();

// Parcel Delivery
builder.Services.AddScoped<
    IParcelDeliveryService,
    ParcelDeliveryService>();

// Flat Transfer
builder.Services.AddScoped<
    IFlatTransferService,
    FlatTransferService>();

// Resident
builder.Services.AddScoped<IResidentService, ResidentService>();

// Complaint
builder.Services.AddScoped<IComplaintService, ComplaintService>();

// Payment
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Emergency
builder.Services.AddScoped<IEmergencyService, EmergencyService>();

// ==================================================
// Repositories
// ==================================================

// User
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Building
builder.Services.AddScoped<
    IBuildingRepository,
    BuildingRepository>();

// Notice
builder.Services.AddScoped<
    INoticeRepository,
    NoticeRepository>();

// Document
builder.Services.AddScoped<
    IDocumentRepository,
    DocumentRepository>();

// Flat
builder.Services.AddScoped<IFlatRepository, FlatRepository>();

// Maintenance
builder.Services.AddScoped<
    IMaintenanceRepository,
    MaintenanceRepository>();

// Parking
builder.Services.AddScoped<
    IParkingRepository,
    ParkingRepository>();

// Staff
builder.Services.AddScoped<IStaffRepository, StaffRepository>();

// Visitor
builder.Services.AddScoped<
    IVisitorRepository,
    VisitorRepository>();

// Parcel Delivery
builder.Services.AddScoped<
    IParcelDeliveryRepository,
    ParcelDeliveryRepository>();

// Flat Transfer
builder.Services.AddScoped<
    IFlatTransferRepository,
    FlatTransferRepository>();

// Resident
builder.Services.AddScoped<
    IResidentRepository,
    ResidentRepository>();

// Complaint
builder.Services.AddScoped<
    IComplaintRepository,
    ComplaintRepository>();

// Payment
builder.Services.AddScoped<
    IPaymentRepository,
    PaymentRepository>();

// Emergency
builder.Services.AddScoped<
    IEmergencyRepository,
    EmergencyRepository>();

// ==================================================
// CORS - Angular
// ==================================================

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

// ==================================================
// Build
// ==================================================

var app = builder.Build();

// ==================================================
// OpenAPI
// ==================================================

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// ==================================================
// Middleware
// ==================================================

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors("AngularPolicy");

app.UseAuthentication();

app.UseAuthorization();

// ==================================================
// Controllers
// ==================================================

app.MapControllers();

// ==================================================
// Run
// ==================================================

app.Run();

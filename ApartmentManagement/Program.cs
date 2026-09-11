using ApartmentApplication.Interfaces_Service;
using ApartmentApplication.Mapping;
using ApartmentApplication.Services;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using ApartmentInfrastructure.Repositories;
using ApartmentManagement.Application.Interfaces.Services;
using ApartmentManagement.Application.Services;
using ApartmentManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddDbContext<ApartmentDbcontext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ApartmentCS"));
});

// --------------------------------------------------
// AutoMapper
// --------------------------------------------------

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(MappingProfile).Assembly);

// --------------------------------------------------
// Application Services
// --------------------------------------------------

builder.Services.AddScoped<IResidentService, ResidentService>();

builder.Services.AddScoped<IComplaintService, ComplaintService>();

builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IEmergencyService, EmergencyService>();

// --------------------------------------------------
// Repository Services
// --------------------------------------------------

builder.Services.AddScoped<IResidentRepository, ResidentRepository>();

builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IEmergencyRepository, EmergencyRepository>();

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

// --------------------------------------------------
// Build application
// --------------------------------------------------

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

app.UseCors("AngularPolicy");

app.UseAuthorization();

// --------------------------------------------------
// Controllers
// --------------------------------------------------

app.MapControllers();

app.Run();
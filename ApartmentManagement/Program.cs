
using ApartmentApplication.Interfaces_Service;
using ApartmentApplication.Mapping;
using ApartmentApplication.Services;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using ApartmentInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApartmentDbContext>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("ApartmentCS")
               )
           );

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

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseCors(p => p
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

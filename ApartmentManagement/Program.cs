using ApartmentApplication.Interfaces_Service;
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

            // Add DbContext
            builder.Services.AddDbContext<ApartmentDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register Repositories
            builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
            builder.Services.AddScoped<IParcelDeliveryRepository, ParcelDeliveryRepository>();
            builder.Services.AddScoped<IFlatTransferRepository, FlatTransferRepository>();

            // Register Services
            builder.Services.AddScoped<IVisitorService, VisitorService>();
            builder.Services.AddScoped<IParcelDeliveryService, ParcelDeliveryService>();
            builder.Services.AddScoped<IFlatTransferService, FlatTransferService>();

            // Add services to the container
            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
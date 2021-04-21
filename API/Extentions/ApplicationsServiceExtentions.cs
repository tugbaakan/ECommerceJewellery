using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extentions
{
    public static class ApplicationsServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config )
        {
            var server = config["DBServer"];
            var port = config["DBPort"] ;
            var userId = config["DBUser"] ;
            var password = config["DBPassword"] ;
            var database = config["Database"];

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection") ??
                     $"Server={server},{port}; Database={database}; User Id={userId};Password={password}");
            });

            return services;
        }         
        
    }
}
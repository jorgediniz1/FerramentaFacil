using FerramentaFacil.Application.Interfaces;
using FerramentaFacil.Application.Services;
using FerramentaFacil.Domain.Interfaces.Repository;
using FerramentaFacil.Infra.Data.Context;
using FerramentaFacil.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FerramentaFacil.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
          
            //Application -Services
            services.AddScoped<IFerramentaService, FerramentaService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            // Infra - Data
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IFerramentaRepository, FerramentaRepository>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));




            return services;
        }
    }
}

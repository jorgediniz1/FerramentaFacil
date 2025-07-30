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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"), 
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IFerramentaRepository, FerramentaRepository>();

            return services;
        }
    }
}

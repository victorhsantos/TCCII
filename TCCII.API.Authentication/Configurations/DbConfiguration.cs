using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TCCII.Deputados.Core.Entities.Identity;
using TCCII.Deputados.Infrastructure.Data;

namespace TCCII.Deputados.API.Configurations
{
    public static class DbConfiguration
    {
        public static IServiceCollection UseDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DeputadosDbContext>(options =>
                options.UseSqlServer(connectionString)
                );

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DeputadosDbContext>()
                .AddDefaultTokenProviders();            

            return services;
        }        
    }
}

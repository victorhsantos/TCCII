using Microsoft.EntityFrameworkCore;
using TCCII.Deputados.Infrastructure.Data;

namespace TCCII.Deputados.API.Configurations
{
    public static class DBManagementConfiguration
    {
        public static async Task MigrationInitialization(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var serviceDB = serviceScope.ServiceProvider.GetService<DeputadosDbContext>();
                await serviceDB.Database.MigrateAsync();
            }
        }
    }
}

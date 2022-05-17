using Microsoft.EntityFrameworkCore;

namespace Acelero.GestaoAcesso.API.Services
{
    public static class DBManagementConfiguration
    {
        public static async Task MigrationInitialization(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var serviceDB = serviceScope.ServiceProvider.GetService<DbContext>();
                await serviceDB.Database.MigrateAsync();
            }
        }
    }
}

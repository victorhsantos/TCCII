using TCCII.API.Authentication.API.Intefaces;
using TCCII.API.Authentication.API.Services;
using TCCII.Core.Interfaces;
using TCCII.Core.Interfaces.Repositories;
using TCCII.Core.Services;
using TCCII.Infrastructure.Repositories;

namespace Acelero.GestaoAcesso.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Services

            services.AddScoped<IContaServices, ContaServices>();
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IDeputadosServices, DeputadosServices>();

            #endregion


            #region Repository 

            services.AddScoped<IDeputadosRepository, DeputadosRepository>();
            services.AddScoped<IUserDeputadosRepository, UserDeputadosRepository>();

            #endregion

            return services;
        }
    }
}

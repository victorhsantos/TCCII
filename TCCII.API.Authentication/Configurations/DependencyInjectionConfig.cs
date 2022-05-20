using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Services;
using TCCII.Deputados.Core.Interfaces;
using TCCII.Deputados.Core.Interfaces.Repositories;
using TCCII.Deputados.Core.Services;
using TCCII.Deputados.Infrastructure.Repositories;

namespace TCCII.Deputados.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Services

            services.AddScoped<IContaServices, ContaServices>();
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IDeputadoServices, DeputadosServices>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();            

            #endregion


            #region Repository 

            services.AddScoped<IDeputadosRepository, DeputadosRepository>();
            services.AddScoped<IUserDeputadosRepository, UserDeputadosRepository>();

            #endregion

            return services;
        }
    }
}

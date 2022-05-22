using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Services;
using TCCII.Deputados.Core.Services;
using TCCII.Deputados.Core.Interfaces;
using TCCII.Deputados.Core.Interfaces.Repositories.Base;
using TCCII.Deputados.Infrastructure.Repositories.Base;

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
            services.AddScoped<IDespesasServices, DespesasServices>();
            
            #endregion

            #region Repository 

            services.AddScoped<IUnitOfWork, UnitOfWork>();                        

            #endregion

            return services;
        }
    }
}

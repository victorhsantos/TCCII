using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace TCCII.Deputados.API.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection ConfigureWebApi(this IServiceCollection services)
        {

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(ErrorResponseFilter));
            //});

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;                
                options.Password.RequireDigit = true;                
                options.Password.RequiredLength = 8;
            });

            services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromMinutes(5));

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Deputados",
                    Description = "API de Deputados",
                    Version = "1.0"
                });                
            });

            return services;
        }
    }
}

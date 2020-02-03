using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BE.Lib.Swagger
{
    public static class SwaggerDI
    {
        public static IServiceCollection AddSwaggerUICore(this IServiceCollection services, bool useJwtBearer, OpenApiInfo openApiInfo)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("Uri-Name", openApiInfo);
                options.EnableAnnotations();
                if (useJwtBearer)
                {
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });
                    options.AddSecurityRequirement(
                            new OpenApiSecurityRequirement {
                                { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] { } /*new[] { swaggerCoreOptions.DefaultBearer*/ }  });
                }

            });

            return services;
        }
    }
}

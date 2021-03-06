using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extension
{
    public static class SwaggerServiceExtensions
    {

        public static IServiceCollection AddSwaggerDocumentation( this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SkiNet API", Version = "v1"});

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorisation",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement {{securitySchema, new[]
                {"Bearer"}}};
                c.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation( this IApplicationBuilder app)
        {
            app.UseSwagger();
            
            // have an error telling me 'ApiValidationErrorResponse' does not contain a definition for 'Errors' [API]
            // Continue on however as the code for section 5 surpasses this and will change again - there is no code for comparision so get to end of 5 and see where you stand
            app.UseSwaggerUI(c => 
                {c.SwaggerEndpoint("/swagger/v1/swagger.json", "Buy & Sell API v1");});

            return app;
        }
    }
}
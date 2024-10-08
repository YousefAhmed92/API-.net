using Microsoft.OpenApi.Models;

namespace Store.Web.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumntation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                // Define the Swagger document details
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Store API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Test",
                        Email = "yousef@gmail.com",
                        Url = new Uri("https://twitter.com/jwalkner")
                    }
                });

                // Define the security scheme for JWT
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization", // Header name for the bearer token
                    Type = SecuritySchemeType.Http, // Type of the security scheme
                    Scheme = "bearer", // Use bearer authentication scheme
                    BearerFormat = "JWT", // Indicate that this is a JWT token
                    In = ParameterLocation.Header, // Location of the token (header)
                    Description = "Enter 'Bearer' followed by a space and the JWT token.",

                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };

                // Add security definition (bearer)
                options.AddSecurityDefinition("Bearer", securityScheme);

                // Add security requirements (use the security scheme defined above)
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        securityScheme,
                        new string[] {} // No specific scopes needed here
                    }
                });
            });

            return services;
        }
    }
}

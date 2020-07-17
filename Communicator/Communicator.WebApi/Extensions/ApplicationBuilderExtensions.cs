using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerAndUI(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                options.OAuthClientId("swaggerui_client");
                options.OAuthClientSecret("swaggerui_secret");
                options.OAuthAppName("SWAGGER UI FOR WEB API");
                options.OAuthUsePkce();
            });
            return app;
        }
    }
}

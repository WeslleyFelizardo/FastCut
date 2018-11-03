using FastCut.Api.Filters;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCut.Api.Settings
{
    public static class SwaggerSetting
    {
        public static void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Swagger JSON Doc
            app.UseSwagger();

            // Swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                options.RoutePrefix = string.Empty;

                options.OAuthClientId("fastcut_api_swagger");
                options.OAuthAppName("FastCut API - Swagger"); // presentation purposes only
            });
        }

        public static void ConfigureIdentitySevrer(IServiceCollection services)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:61618"; // auth server base endpoint (will use to search for disco doc)
                    options.ApiName = "fastcut_api"; // required audience of access tokens
                    options.RequireHttpsMetadata = false; // dev only!
                });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Protected API", Version = "v1" });

                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Flow = "implicit", // just get token via browser (suitable for swagger SPA)
                    AuthorizationUrl = "http://localhost:61618/connect/authorize",
                    Scopes = new Dictionary<string, string> { { "fastcut_api", "FastCut API - full access" } },


                });
                options.OperationFilter<HeaderTenantOperationFilter>();
                options.OperationFilter<AuthorizeCheckOperationFilter>(); // Required to use access token
            });
        }
    }
}

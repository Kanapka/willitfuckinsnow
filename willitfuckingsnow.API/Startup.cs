using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using willitfuckingsnow.API.Services;
using System.Net.Http;

namespace willitfuckingsnow.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var settings = Configuration.Get<Settings>();
            services
                .AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    var contractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                    o.SerializerSettings.ContractResolver = contractResolver;
                });

            services
                .AddSingleton<IAuthorization>(_ => new Authorization(settings.ApiKeyPath))
                .AddSingleton(new HttpClient())
                .AddSingleton<IExternalAPI>(c
                    => new ExternalAPI(
                        settings.ApiEndpoint,
                        c.GetRequiredService<HttpClient>(),
                        c.GetRequiredService<IAuthorization>()))
                ;

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}

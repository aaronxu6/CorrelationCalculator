using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Interview 
{ 
    public class Startup 
    { 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddCors(o => o.AddPolicy("AllowAll", builder => 
            {
                builder.AllowAnyOrigin();
            }));
            // base address can be defined in config instead of hard coding.
            services.AddHttpClient<IValetService, ValetService>()
                .ConfigureHttpClient((_, options) => options.BaseAddress = new Uri("https://www.bankofcanada.ca/valet"));
            
            services.AddSingleton<ICorrelationCalculator, CorrelationCalculator>();
        }

        public void Configure(IApplicationBuilder app) 
        { 
            app.UseCors("AllowAll");
            app.UseMvcWithDefaultRoute();
        } 
    } 
}

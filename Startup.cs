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
            // base address can be defined in config instead of hard coding.
            services.AddHttpClient<IValetService, ValetService>()
                .ConfigureHttpClient((_, options) => options.BaseAddress = new Uri("https://www.bankofcanada.ca/valet"));
        }

        public void Configure(IApplicationBuilder app) 
        { 
            app.UseMvcWithDefaultRoute();
        } 
    } 
}

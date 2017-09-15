using Fiver.Mvc.ModelBinding.Custom.Lib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Fiver.Mvc.ModelBinding.Custom
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddDataProtection();
            
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new ProtectedIdModelBinderProvider());
                options.Filters.Add(typeof(ProtectedIdResultFilter));
            });
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}

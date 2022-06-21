using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Samples.Contracts;
using Samples.Services;

namespace Samples.Functions.EventBased
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
        {
            base.ConfigureServices(context, services);
            services.AddScoped<ICountryApi, CountryApi>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsPaper.Accounts.Configure;
using NewsPaper.Accounts.ConfigureServices;
using NewsPaper.Accounts.Infrastructure.DependencyInjection;

namespace NewsPaper.Accounts
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
            ConfigureServicesBase.ConfigureServices(services, Configuration);
            ConfigureServicesMassTransitRabbitMq.ConfigureService(services, Configuration);
            ConfigureServicesControllers.ConfigureServices(services);
            DependencyContainerRegistrations.Common(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AutoMapper.IConfigurationProvider mapper)
        {
            ConfigureCommon.Configure(app, env, mapper);
            ConfigureEndpoints.Configure(app);
        }
    }
}

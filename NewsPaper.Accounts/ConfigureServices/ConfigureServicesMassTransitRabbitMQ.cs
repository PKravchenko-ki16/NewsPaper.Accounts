using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsPaper.Accounts.MassTransit.Authors;
using NewsPaper.Accounts.MassTransit.Editors;
using NewsPaper.Accounts.MassTransit.Users;
using NewsPaper.MassTransit.Configuration;
using ConfigureServicesMassTransit = NewsPaper.MassTransit.Configuration.ConfigureServicesMassTransit;

namespace NewsPaper.Accounts.ConfigureServices
{
    public class ConfigureServicesMassTransitRabbitMq
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("MassTransit");
            ConfigureServicesMassTransit.ConfigureServices(services, configuration, new MassTransitConfiguration()
            {
                IsDebug = section.GetValue<bool>("IsDebug"),
                ServiceName = "Accounts",
                Configurator = busMassTransit =>
                {
                    busMassTransit.AddConsumer<GetGuidAuthorConsumer>();
                    busMassTransit.AddConsumer<GetGuidEditorConsumer>();
                    busMassTransit.AddConsumer<GetGuidUserConsumer>();
                    busMassTransit.AddConsumer<GetNikeNameAuthorConsumer>();
                    busMassTransit.AddConsumer<GetNikeNameEditorConsumer>();
                    busMassTransit.AddConsumer<GetNikeNameUserConsumer>();
                }
            });
        }
    }
}

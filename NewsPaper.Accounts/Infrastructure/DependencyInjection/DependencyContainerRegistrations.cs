using Microsoft.Extensions.DependencyInjection;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.DAL;

namespace NewsPaper.Accounts.Infrastructure.DependencyInjection
{
    public class DependencyContainerRegistrations
    {
        public static void Common(IServiceCollection services)
        {
            services.AddTransient<ApplicationContext>();
            services.AddTransient<OperationAuthorsAccounts>();
        }
    }
}

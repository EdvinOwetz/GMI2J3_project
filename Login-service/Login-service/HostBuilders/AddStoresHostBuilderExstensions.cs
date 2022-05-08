using Login_service.State.Authenticators;
using Login_service.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_service.HostBuilders
{
    public static class AddStoresHostBuilderExstensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                //authenticator that makes the login and register possible
                services.AddSingleton<IAuthenticator, Authenticator>();
            });
            return host;
        }
    }
}

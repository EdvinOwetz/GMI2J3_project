using Login_DataManager.Services;
using LoginDomain.Services;
using LoginDomain.Services.AuthenticationServices;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_service.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                //add services here like dataservice etc
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IDataServiceSql, DataServiceSql>();
                services.AddSingleton<IAccountDataService, AccountDataService>();
                services.AddSingleton<IPasswordHasher, PasswordHasher>();
            });
            return host;
        }
    }
}

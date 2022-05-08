using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_service.HostBuilders
{
    public static class AddConfigHostBuilderExtensions
    {
        public static IHostBuilder AddConfig(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
            });

            return host;
        }
    }
}

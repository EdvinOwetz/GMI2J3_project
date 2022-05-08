using Login_service.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_service.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                //Add our Main window with datacontext so our commands will follow along
                //Because we have a constructor inside the mainwindow we have the to lambda express it 
                //Then we get the addscoped<mainViewModel> from the get required service that gives us the mainviewmodel
                //By doing this we use dependecy injection on the mainwindow aswell
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });
            return host;
        }
    }
}

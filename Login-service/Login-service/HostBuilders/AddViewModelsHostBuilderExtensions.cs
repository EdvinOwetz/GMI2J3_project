using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Login_service.State.Authenticators;
using Login_service.State.Navigators;
using Login_service.ViewModels;
using Login_service.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_service.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                //Add all our viewmodels
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<AccountManagementViewModel>();
                services.AddSingleton<RegisterViewModel>();
                //Add the mainview that holds all viewmodels (UserControls)
                services.AddSingleton<MainViewModel>();

                //Add the factory that creates the viewmodels and have constraint that they are viewmodels
                services.AddSingleton<ILoginServiceViewModelFactory, LoginServiceViewModelFactory>();

                //navigator
                //services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => services.GetRequiredService<LoginViewModel>());
                //services.AddSingleton<CreateViewModel<AccountManagementViewModel>>(services => () => services.GetRequiredService<AccountManagementViewModel>());
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));
                //test
                services.AddSingleton<CreateViewModel<AccountManagementViewModel>>(services => () => CreateUpdateViewModel(services));

                //renavigators
                services.AddSingleton<ViewModelRenavigator<LoginViewModel>>();                
                services.AddSingleton<ViewModelRenavigator<RegisterViewModel>>();
                //test
                services.AddSingleton<ViewModelRenavigator<AccountManagementViewModel>>();
            });
            return host;

        //navigators in the loginview
        static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelRenavigator<AccountManagementViewModel>>(),
                services.GetRequiredService<ViewModelRenavigator<RegisterViewModel>>());
        }
            //navigators in the registerview
        static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {

            return new RegisterViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelRenavigator<LoginViewModel>>());
        }
            //test
        static AccountManagementViewModel CreateUpdateViewModel(IServiceProvider services)
        {

            return new AccountManagementViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelRenavigator<AccountManagementViewModel>>(),
                services.GetRequiredService<ViewModelRenavigator<LoginViewModel>>());
        }
            //navigator in the mainview
        }
    }
}

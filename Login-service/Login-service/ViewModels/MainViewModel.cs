using Login_service.Commands;
using Login_service.State.Authenticators;
using Login_service.State.Navigators;
using Login_service.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Login_service.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ILoginServiceViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand LogoutCommand { get; }
        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public MainViewModel(INavigator navigator, ILoginServiceViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _navigator = navigator;
            _authenticator = authenticator;
            _viewModelFactory = viewModelFactory;
            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            LogoutCommand = new LogoutCommand(authenticator);
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            //Here i decide which viewmodel I want as start view
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}


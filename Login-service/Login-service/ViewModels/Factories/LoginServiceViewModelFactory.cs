using Login_service.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_service.ViewModels.Factories
{
    /// <summary>
    /// this is a switch case that contains all enums and then from the enums
    /// shows the specific viewmodel depending on the enum.
    /// </summary>
    public class LoginServiceViewModelFactory :ILoginServiceViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<AccountManagementViewModel> _createAccountManagementViewModel;
        private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;

        public LoginServiceViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel,
                                            CreateViewModel<AccountManagementViewModel> createAccountManagementViewModel,
                                            CreateViewModel<RegisterViewModel> createRegisterViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createAccountManagementViewModel = createAccountManagementViewModel;
            _createRegisterViewModel = createRegisterViewModel;
        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Management:
                    return _createAccountManagementViewModel();
                case ViewType.Register:
                    return _createRegisterViewModel();
                default:
                    throw new ArgumentException($"The ViewType Does not have a ViewModel");
            }
        }
    }
}

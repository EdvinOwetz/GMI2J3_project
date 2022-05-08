using Login_service.State.Authenticators;
using Login_service.State.Navigators;
using Login_service.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LoginDomain.Services.AuthenticationServices.IAuthenticationService;

namespace Login_service.Commands
{
    public class UpdateCommand : AsyncCommandBase
    {
        private readonly AccountManagementViewModel _accountManagementViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _accountManagementRenavigator;

        public UpdateCommand(AccountManagementViewModel accountManagementViewModel,
                             IAuthenticator authenticator,
                             IRenavigator accountManagementRenavigator)
        {
            _accountManagementViewModel = accountManagementViewModel;
            _authenticator = authenticator;
            _accountManagementRenavigator = accountManagementRenavigator;

            _accountManagementViewModel.PropertyChanged += AccountManagementViewModel_PropertyChanged;
        }
        public override bool CanExecute(object parameter)
        {
            return _accountManagementViewModel.CanRegister && base.CanExecute(parameter);
        }

        private void AccountManagementViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AccountManagementViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                _accountManagementViewModel.ErrorMessage = string.Empty;

                RegistrationResult registrationResult = await _authenticator.Register(_accountManagementViewModel.Username,
                                                                                      _accountManagementViewModel.Password,
                                                                                      _accountManagementViewModel.ConfirmPassword,
                                                                                      _accountManagementViewModel.Email);
                switch (registrationResult)
                {
                    case RegistrationResult.PasswordsDoNotMatch:
                        _accountManagementViewModel.ErrorMessage = "Password does not match confirm password.";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _accountManagementViewModel.ErrorMessage = "An account for this email already exists.";
                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        _accountManagementViewModel.ErrorMessage = "An account for this username already exists.";
                        break;
                    case RegistrationResult.InvalidEmailAddress:
                        _accountManagementViewModel.ErrorMessage = "Invalid e-mail address.";
                        break;
                    default:
                        _accountManagementViewModel.ErrorMessage = "Update failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _accountManagementViewModel.ErrorMessage = $"Update failed";
            }
        }
    }
}

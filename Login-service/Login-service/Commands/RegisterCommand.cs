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
    public class RegisterCommand : AsyncCommandBase
    {

        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public RegisterCommand(RegisterViewModel registerViewModel,
                               IAuthenticator authenticator,
                               IRenavigator registerRenavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;

            _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister && base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                _registerViewModel.ErrorMessage = string.Empty;

                RegistrationResult registrationResult = await _authenticator.Register(_registerViewModel.Username,
                                                                                      _registerViewModel.Password,
                                                                                      _registerViewModel.ConfirmPassword,
                                                                                      _registerViewModel.Email);
                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Renavigate();
                        //Lägg till message box för account created
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        _registerViewModel.ErrorMessage = "Password does not match confirm password.";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessage = "An account for this email already exists.";
                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        _registerViewModel.ErrorMessage = "An account for this username already exists.";
                        break;
                    case RegistrationResult.InvalidEmailAddress:
                        _registerViewModel.ErrorMessage = "Invalid e-mail address.";
                        break;
                    default:
                        _registerViewModel.ErrorMessage = "Registration failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = $"Registration failed";
            }

        }
        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
using Login_service.Commands;
using Login_service.State.Authenticators;
using Login_service.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Login_service.ViewModels
{
    public class AccountManagementViewModel: ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public bool CanRegister => !string.IsNullOrEmpty(Username) &&
                           !string.IsNullOrEmpty(Password) &&
                           !string.IsNullOrEmpty(ConfirmPassword) &&
                           !string.IsNullOrEmpty(Email);
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public AccountManagementViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator accountManagementRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();
            UpdateCommand = new UpdateCommand(this, authenticator, accountManagementRenavigator);
            DeleteCommand = new RenavigateCommand(loginRenavigator);
        }
    }
}

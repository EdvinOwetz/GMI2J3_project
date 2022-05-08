using Login_service.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Login_service.Commands
{
    public class LogoutCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;

        public LogoutCommand(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            MessageBoxResult result = MessageBox.Show("Do you really want to logout and shut it down?", "Close Window?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _authenticator.Logout();
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Misson ABORT!");
                    break;
            }
        }
    }
}

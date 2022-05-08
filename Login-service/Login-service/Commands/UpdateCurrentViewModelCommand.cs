using Login_service.State.Navigators;
using Login_service.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Login_service.Commands
{
    /// <summary>
    /// Detta är en "Command" som gör att man kan navigera runt i viewmodeln
    ///
    /// </summary>
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        //För att få med Interfacet INavigator måste jag skapa en konstruktor som tar med implementationen
        private readonly INavigator _navigator;
        private readonly ILoginServiceViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, ILoginServiceViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Med hjälp av enum som finns i Inavigator kan jag styra vilken viewmodel som används
        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}

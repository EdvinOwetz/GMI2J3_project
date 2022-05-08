using Login_service.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_service.ViewModels.Factories
{
    public interface ILoginServiceViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}

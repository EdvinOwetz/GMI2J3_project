using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Login_service.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isExecuting;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            IsExecuting = true;

            await ExecuteAsync(parameter);

            IsExecuting = false;
        }
        public abstract Task ExecuteAsync(object parameter);
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

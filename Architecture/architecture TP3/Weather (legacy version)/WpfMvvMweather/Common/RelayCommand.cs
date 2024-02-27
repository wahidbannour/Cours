using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace Ritege.ViewModels
{
    public class RelayCommand : ICommand
    {
        #region Fieds
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        private readonly Func<object,Task> _command;

        #endregion

        #region Constructor
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        /*     public RelayCommand(Func<object,Task> command)
             {
                 _command = command;
             } */

        public RelayCommand(Func<object, Task> command, Predicate<object> canExecute)
        {
            _command = command;
            _canExecute = canExecute;
        }
        #endregion

        #region members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        //public void Execute(object parameter)
        //{
        //    _execute(parameter);
        //}

        public async void Execute(object parameter)
        {
            if (_command != null)
                await ExecuteAsync(parameter);
            else
                _execute(parameter);
        }

        public async Task ExecuteAsync(object parameter)
        {
             await _command(parameter);
        }
        #endregion


    }
}

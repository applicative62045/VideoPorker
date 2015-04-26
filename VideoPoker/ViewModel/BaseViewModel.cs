using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace VideoPoker.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged impliments
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ICommand CreateCommand(Action<object> command, Func<object, bool> canExecute)
        {
            return new _DelegateCommand(command, canExecute);
        }

        private class _DelegateCommand : ICommand
        {
            private Action<object> _Command;
            private Func<object, bool> _CanExecute;

            public bool CanExecute(object parameter)
            {
                return _CanExecute == null ? true : _CanExecute(parameter);
            }

            public event System.EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested += value; }
            }

            public void Execute(object parameter)
            {
                _Command(parameter);
            }

            public _DelegateCommand(Action<object> command, Func<object, bool> canExecute)
            {
                _Command = command;
                _CanExecute = canExecute;
            }
        }
    }
}

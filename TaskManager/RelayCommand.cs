using System;
using System.Windows.Input;

namespace TaskManager
{   
    /// <summary>
    /// Klasa reprezentujaca przekazywana komende
    /// </summary>
    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) 
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Funcja sprawdzajaca czy mozna wykonac komende
        /// </summary>
        /// <param name="parameter"> Komenda</param>
        /// <returns></returns>
        public bool CanExecute(object parameter) 
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Funkcja odpowiadajaca za wykonanie komendy
        /// </summary>
        /// <param name="parameter">Komenda</param>
        public void Execute(object parameter) 
        {
            _execute(parameter);
        }
    }
}

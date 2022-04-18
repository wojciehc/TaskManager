using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ViewModel 
{   
    /// <summary>
    /// Klasa reprezentujaca widok glowny aplikacji
    /// </summary>
    class MainViewModel :  ObservableObject
    {

        public RelayCommand TasksViewCommand { get; set; }

        public RelayCommand AddTaskViewCommand { get; set; }

        public TasksViewModel TasksVM { get; set; }

        public AddTaskViewModel AddTaskVM { get; set; } 

        private object _currentView;

        public object CurrentView 
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Kontruktor ustawiajcy obecny (domyslny) widok na widok listy zadan
        /// </summary>
        public MainViewModel() 
        {
            TasksVM = new TasksViewModel();
            AddTaskVM = new AddTaskViewModel();

            CurrentView = TasksVM;

            TasksViewCommand = new RelayCommand(o =>
            {
                CurrentView = TasksVM;
            });

            AddTaskViewCommand = new RelayCommand(o =>
            {
                CurrentView = AddTaskVM;
            });

        }

    }
}

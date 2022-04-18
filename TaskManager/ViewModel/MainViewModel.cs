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
        /// <summary>
        /// Komenda reprezentujaca widok listy zadan
        /// </summary>
        public RelayCommand TasksViewCommand { get; set; }

        /// <summary>
        /// Komenda reprezentujaca widok dodania zadania
        /// </summary>
        public RelayCommand AddTaskViewCommand { get; set; }

        /// <summary>
        /// Model widoku listy zadan
        /// </summary>
        public TasksViewModel TasksVM { get; set; }

        /// <summary>
        /// Model widoku dodania zadania
        /// </summary>
        public AddTaskViewModel AddTaskVM { get; set; } 

        /// <summary>
        /// Zmienna prywatka reprezentujaca obecny widok
        /// </summary>
        private object _currentView;

        /// <summary>
        /// Obecny widok
        /// </summary>
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
        /// Kontruktor ustawiajcy obecny (domyslny) widok na widok listy zadan i przypisujacy odpowiednim komenda dane widoki
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

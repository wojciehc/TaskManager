using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ViewModel 
{
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManager.ViewModel
{
    internal class TasksViewModel : ObservableObject
    {
        ToDoListContext db = new ToDoListContext();
        public ObservableCollection<Task> Tasks { get; set; }

        public ICommand DeleteCommand { get; }

        public TasksViewModel() 
        {
            Tasks = new ObservableCollection<Task>(db.Tasks.OrderByDescending(t => t.StartDate));
            DeleteCommand = new RelayCommand(DeleteTask);
        }

        public void DeleteTask(object param)
        {
            var task = param as Task;
            if (task != null)
            {
                Tasks.Remove(task);

                db.Tasks.Remove(task);
                db.SaveChanges();
            }
        }
    }
}

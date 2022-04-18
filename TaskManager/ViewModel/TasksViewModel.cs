using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace TaskManager.ViewModel
{   
    /// <summary>
    /// Klasa reprezentujaca widok listy zadan
    /// </summary>
    internal class TasksViewModel : ObservableObject
    {
        ToDoListContext db = new ToDoListContext();
        public ObservableCollection<Task> Tasks { get; set; }

        public ICommand DeleteCommand { get; }
        
        /// <summary>
        /// Kontruktor inicjalizujacy kolekcje zadan wraz z posortowaniem wzgledem deadlinu
        /// </summary>
        public TasksViewModel() 
        {
            Tasks = new ObservableCollection<Task>(db.Tasks.OrderBy(t => t.Deadline));
            DeleteCommand = new RelayCommand(DeleteTask);
        }

        /// <summary>
        /// Funckja do usuwania zadania z listy zadan
        /// </summary>
        /// <param name="param"> Dany element z listy</param>
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

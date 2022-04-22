using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



namespace TaskManager.View
{
    /// <summary>
    /// Logika dla pliku AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : UserControl
    {
        ToDoListContext context;

        /// <summary>
        /// Konstruktor inicjalizujacy komponenty
        /// </summary>
        public AddTaskView()
        {
            InitializeComponent();

            context = new ToDoListContext();
        }
            
        /// <summary>
        /// Funkcja odpowiadająca za napis w bloku tekstowym, gdy zlapie on focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter your " + tb.Name || tb.Text == tb.Name)
            {
                tb.Text = string.Empty;
                tb.Foreground = Brushes.Black;
            }
        }

        /// <summary>
        /// Funkcja odpowiadająca za napis w bloku tekstowym, gdy straci on focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Enter your " + ((TextBox)sender).Name;
                ((TextBox)sender).Foreground = Brushes.Gray;
            }
        }

        /// <summary>
        /// Funkcja przypisana do przycisku AddNewTaskButton odpowiadająca za dodanie do listy nowego zadania
        /// Wyswietla komunikat po sukcesie lub po porazce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskName.Text != "Enter your TaskName" && !string.IsNullOrWhiteSpace(TaskName.Text))
            {
                if (Comment.Text == "Enter your Comment")
                {
                    Comment.Text = string.Empty;
                }
                    Task task = new Task()
                {
                    Name = TaskName.Text,
                    Comment = Comment.Text,
                    StartDate = DateTime.Now,
                    Deadline = DeadlineDatePicker.SelectedDate ?? DateTime.Now,
                    IsCompleted = false,
                };
           
                context.Tasks.Add(task);
                context.SaveChanges();

                TaskName.Text = "Enter your TaskName";
                TaskName.Foreground = Brushes.Gray;
                Comment.Text = "Enter your Comment";
                Comment.Foreground = Brushes.Gray;

                Information.Foreground = Brushes.LightGreen;
                Information.Text = "Added new task";
            }
            else 
            {
                Information.Foreground = Brushes.Red;
                Information.Text = "TaskName can't be empty!";
            }
            
        }
    }

}

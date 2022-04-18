using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



namespace TaskManager.View
{
    /// <summary>
    /// Interaction logic for AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : UserControl
    {
        ToDoListContext context;

        public AddTaskView()
        {
            InitializeComponent();

            context = new ToDoListContext();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter your " + tb.Name || tb.Text == tb.Name)
            {
                tb.Text = string.Empty;
                tb.Foreground = Brushes.Black;
            }
        }

        public void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Enter your " + ((TextBox)sender).Name;
                ((TextBox)sender).Foreground = Brushes.Gray;
            }
        }

        private void AddNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
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
        }
    }

}

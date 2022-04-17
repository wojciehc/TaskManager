using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


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
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void AddNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task()
            {
                Name = TaskNameTextBox.Text,
                Comment = CommentTextBox.Text,
                StartDate = DateTime.Now,
                Deadline = DeadlineDatePicker.SelectedDate ?? DateTime.Now,
                IsCompleted = false,
            };  
            context.Tasks.Add(task);
            context.SaveChanges();

            TaskNameTextBox.Clear();
            CommentTextBox.Clear();
        }
    }

}

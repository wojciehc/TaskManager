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

namespace TaskManager.Theme.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy TaskBorder.xaml
    /// </summary>
    public partial class TaskBorder : Page
    {
        public TaskBorder()
        {
            TextBlock taskName = new TextBlock();
            taskName.Text = "taskName";
            TextBlock taskContet = new TextBlock();
            taskContet.Text = "taskContet";

            TextBlock startDate = new TextBlock();
            startDate.Text = "startDate";
            TextBlock deadline = new TextBlock();
            deadline.Text = "deadline";

            Border taskBorder = new Border();
            taskBorder.Child = taskName;
            this.Content = taskBorder;
        }
    }
}

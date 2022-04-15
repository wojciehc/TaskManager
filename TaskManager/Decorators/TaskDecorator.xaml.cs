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

namespace TaskManager.Decorators
{
    /// <summary>
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            TextBlock taskName = new TextBlock();
            TextBlock taskDescription = new TextBlock();
            TextBlock startDate = new TextBlock();
            TextBlock endDate = new TextBlock();
            taskName.Text = "namenameTask";
            taskDescription.Text = "descdescTask";
            startDate.Text = "24.03.2013";
            endDate.Text = "27.09.2023";
        }
    }
}

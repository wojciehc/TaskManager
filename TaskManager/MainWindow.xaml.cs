using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateRandomFact();
        }

        private async void NewFactButton_Click(object sender, RoutedEventArgs e)
        {
            await UpdateRandomFact();
        }

        private async System.Threading.Tasks.Task UpdateRandomFact()
        {
            NewFactButton.IsEnabled = false;

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://uselessfacts.jsph.pl/random.json?language=en")
                };

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(body);

                        FactTextBlock.Text = data["text"];
                    }
                }
            }
            catch
            { }

            NewFactButton.IsEnabled = true;
        }
    }
}

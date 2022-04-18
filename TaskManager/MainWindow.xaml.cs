using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;


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
            {
                FactTextBlock.Text = "Coudn't find anything interesting... Check your internet connection";       
            }

            NewFactButton.IsEnabled = true;
        }
    }
}

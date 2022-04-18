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
        /// <summary>
        /// Kontruktor inicjalizujacy
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            UpdateRandomFact();
        }

        /// <summary>
        /// Fukncja przypisana do przycisku NewFactButton odpowiadajaca za pobranie i wyswietlenie nowego faktu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NewFactButton_Click(object sender, RoutedEventArgs e)
        {
            await UpdateRandomFact();
        }
            /// <summary>
            /// Funckja odpowiadajaca za wyslanie zapytania do zewnetrznego api i przekazania faktu do odpowiednego bloku tekstowego
            /// W przypadku braku odpowiedzi wyswietla informacje o problemie
            /// </summary>
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

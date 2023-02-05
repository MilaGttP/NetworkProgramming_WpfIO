using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace NetworkProgramming_WpfIO
{
    public partial class Task1 : Window
    {
        HttpClient client;
        public Task1()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
            response.EnsureSuccessStatusCode();
            string responseBody =  await response.Content.ReadAsStringAsync();
            if (responseBody != null) TB.Text = responseBody;
        }
    }
}

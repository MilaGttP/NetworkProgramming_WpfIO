using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace NetworkProgramming_WpfIO
{
    public partial class Task1 : Window
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://www.gutenberg.org/files/2265/2265.txt");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            TB.Text = reader.ReadToEnd();
        }
    }
}

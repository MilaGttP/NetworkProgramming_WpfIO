using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace NetworkProgramming_WpfIO
{
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HttpWebRequest request= (HttpWebRequest)HttpWebRequest.Create("https://www.gutenberg.org/ebooks/search/?start_index=1&sort_order=downloads");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            TB.Text = reader.ReadToEnd();
        }
    }
}

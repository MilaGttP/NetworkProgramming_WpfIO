using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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

namespace NetworkProgramming_WpfIO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start1Btn_Click(object sender, RoutedEventArgs e)
        {
            const string ip_user = "127.0.0.1";
            const int port = 8000;
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(ip_user);
            IPEndPoint ep = new IPEndPoint(ip, port);
            s.Bind(ep);
            s.Listen(15);
            try
            {
                while (true)
                {
                    Socket ns = s.Accept();
                    TB.Text = $"[{ns.RemoteEndPoint.ToString()}]: Hello server!";
                    ns.Send(System.Text.Encoding.Unicode.GetBytes("Hello client!"));
                    ns.Shutdown(SocketShutdown.Both);
                    ns.Close();
                }
            }
            catch (SocketException ex) { MessageBox.Show(ex.Message); }
        }

        private void Start2Btn_Click(object sender, RoutedEventArgs e)
        {
            const string ip_user = "127.0.0.1";
            const int port = 8000;
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(ip_user);
            IPEndPoint ep = new IPEndPoint(ip, port);
            s.Bind(ep);
            s.Listen(15);
            try
            {
                while (true)
                {
                    Socket ns = s.Accept();
                    TB.Text = $"[{ns.RemoteEndPoint.ToString()}]: Connected";
                    ns.Send(System.Text.Encoding.Unicode.GetBytes(DateTime.Now.ToString()));
                    ns.Shutdown(SocketShutdown.Both);
                    ns.Close();
                }
            }
            catch (SocketException ex) { MessageBox.Show(ex.Message); }
        }
    }
}

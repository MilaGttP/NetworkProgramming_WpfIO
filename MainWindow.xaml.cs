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
        
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            const string ipUser = "127.0.0.1";
            const int port = 8000;
            IPAddress ip = IPAddress.Parse(ipUser);
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(endPoint);
                if (socket.Connected)
                {
                    String strSend = "GET\r\n\r\n";
                    socket.Send(Encoding.Unicode.GetBytes(strSend));
                    byte[] buffer = new byte[1024];
                    int l;
                    do
                    {
                        l = socket.Receive(buffer);
                        TB.Text = Encoding.Unicode.GetString(buffer, 0, l);
                    } while (l > 0);
                }
                else MessageBox.Show("Error");
            }
            catch (SocketException ex) { MessageBox.Show(ex.Message); }
            finally
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
    }
}

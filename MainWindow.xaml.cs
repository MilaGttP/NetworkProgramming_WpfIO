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
        private Socket _udpSocket;
        private IPEndPoint _remoteEndPoint;
        private string _username;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendMessage(string message)
        {
            var data = Encoding.ASCII.GetBytes(message);
            _udpSocket.SendTo(data, _remoteEndPoint);
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                var message = $"{_username}: {MessageTextBox.Text}";
                SendMessage(message);
                MessageTextBox.Text = string.Empty;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                _username = LoginTextBox.Text;
                _udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, 11000);

                SendMessage($"{_username} entered the chat");

                _udpSocket.Bind(new IPEndPoint(IPAddress.Any, 11000));
                _udpSocket.BeginReceive(new byte[1024], 0, 1024, SocketFlags.None, ReceiveCallback, null);
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            var receivedBytes = _udpSocket.EndReceive(ar, ref _remoteEndPoint);
            var message = Encoding.ASCII.GetString(receivedBytes);
            Dispatcher.Invoke(() =>
            {
                ChatTextBox.AppendText(message + Environment.NewLine);
            });
            _udpSocket.BeginReceive(new byte[1024], 0, 1024, SocketFlags.None, ReceiveCallback, null);
        }
    }
}

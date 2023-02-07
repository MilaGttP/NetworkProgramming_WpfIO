using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace NetworkProgramming_WpfIO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailAddress fromAddress = new MailAddress(txtFrom.Text);
                MailAddress toAddress = new MailAddress(txtTo.Text);
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, pass.Name)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Body = txtMessage.Text
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("Mail Sent Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

//nlhskgijwgntbugs - as s password (gmail - milaivanova2609@gmail.com)

namespace NetworkProgramming_WpfIO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static void SendMail2Step(string SMTPServer, int SMTP_Port, string From, string Password, string To, string subject, string body, string[] FileNames)
        {
            try
            {
                var smtpClient = new SmtpClient(SMTPServer, SMTP_Port)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };
                smtpClient.Credentials = new NetworkCredential(From, Password);

                var fromAddress = new MailAddress(From, "Anonym");
                var toAddress = new MailAddress(To, To);
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            SendMail2Step("smtp.gmail.com", 587, from.Text,
            pass.Text, to.Text, subject.Text, message.Text, null);
        }
    }
}

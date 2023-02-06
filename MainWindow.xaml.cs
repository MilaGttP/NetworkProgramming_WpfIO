using System;
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
                MailMessage message = new MailMessage();
                message.From = new MailAddress(txtFrom.Text);
                message.To.Add(txtTo.Text);
                message.Body = txtMessage.Text;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);

                MessageBox.Show("Mail Sent Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

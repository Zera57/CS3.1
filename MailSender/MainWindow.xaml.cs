using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void SendButton_Click(object sender, RoutedEventArgs e)
		{
			if (TBLogin.Text.Length != 0 && TBPassword.Password.Length != 0 && TBEmailto.Text.Length != 0 && TBSubject.Text.Length != 0 && TBMessage.Text.Length != 0)
			{
				EmailSendServiceClass senderService = new EmailSendServiceClass(Data.host, Data.port);

				senderService.InitMessage(TBSubject.Text, TBMessage.Text, new MailAddress(TBLogin.Text), new MailAddress(TBEmailto.Text));

				senderService.Creditionals(TBLogin.Text, TBPassword.SecurePassword);

				senderService.SendMessage();
			}
			else { MessageBox.Show("Type all data"); }
		}

		public static class Data
		{
			public static string host = "smtp.gmail.com";
			public static int port = 587;


		}
	}

	public class EmailSendServiceClass
	{
		SmtpClient client;
		MailMessage message;


		public EmailSendServiceClass(string host, int port)
		{
			client = new SmtpClient(host, port);
			client.EnableSsl = true;
		}

		public void InitMessage(string subject, string body, MailAddress from, MailAddress to)
		{
			message = new MailMessage(from, to);
			message.Subject = subject;
			message.Body = body;
		}

		public void Creditionals(string login, SecureString password)
		{
			client.Credentials = new NetworkCredential
			{
				UserName = login,
				SecurePassword = password
			};
		}

		public void SendMessage()
		{
			try
			{
				client.Send(message);
				MessageBox.Show("Mail sended");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
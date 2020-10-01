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
using MailSender.Models;
using MailSenderService_lib;

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

		private void SendButton_Click(object Sender, RoutedEventArgs e)
		{
			if (!(SenderList.SelectedItem is Sender sender)) return;
			if (!(RecipientList.SelectedItem is Recipient recipient)) return;
			if (!(ServerList.SelectedItem is Server server)) return;
			if (!(MessageList.SelectedItem is Message message))
			{
				TabControl.SelectedIndex = 2;
				MessageBox.Show("Письмо не заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var send_service = new MailSenderService
			{
				ServerAddress = server.Address,
				ServerPort = server.Port,
				UseSSL = server.UseSSL,
				Login = server.Login,
				Password = TextEncoder.Decode(server.Password)
			};

			try
			{
				send_service.SendMessage(sender.Address, recipient.Address, message.Subject, message.Body);
			}
			catch (SmtpException error)
			{
				MessageBox.Show("Ошибка при отправке почты " + error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void OpenScheduler_Click(object sender, RoutedEventArgs e)
		{
			TabControl.SelectedIndex = 1;
		}
	}
}

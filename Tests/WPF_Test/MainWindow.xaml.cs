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

namespace WPF_Test
{
	public partial class WpfMailSender : Window
	{
		#region 1
		//1. Посмотрите внимательно на приложение, при помощи которого мы тестировали возможность отправлять электронные письма и начали изучать WPF.
		//Посмотрите внимательно на код.В коде есть несколько моментов, которые простительны для теста, но непростительны для серьёзного приложения.

		//a.Первый момент: жестко заданные переменные в коде.Например, new SmtpClient("smtp.yandex.ru", 25), в этой строке две жестко заданные переменные:
		//		"smtp.yandex.ru" – smtp-сервер и 25 – порт для этого сервера.В коде много и других жестко заданных переменных: адреса почтовых ящиков, тексты писем, тексты ошибок и др.
		//Задание: добавить в проект WpfTestMailSender public static class, без конструктора и методов.Определить в этом классе статические переменные
		//		и задать им значения.В коде использовать эти переменные вместо жестко заданных.

		//b.Второй момент, который также простителен для тестовой программы и нежелателен для более или менее серьезного приложения. Код, который описывает форму,
		//		и код, который занимается непосредственно рассылкой, содержится в одном классе.
		//Задание: добавить к проекту WpfTestMailSender public class, назвать его, например, EmailSendServiceClass с конструктором.Создать в этом классе
		//		методы (или метод), которые будут заниматься рассылкой писем.Класс надо создать таким образом, чтобы его можно было легко перенести в другой проект.

		//c.В коде присутствует MessageBox с выводом ошибки в случае невозможности отправить письма. В принципе, MessabeBox — не криминал и даже в серьезных
		//		проектах они присутствуют, но всё-таки окно со своим стилем выглядит лучше.
		//Задание: по аналогии с формой, которая выводит сообщение «Работа завершена», создайте ещё одну для вывода текста ошибки.Цвет текста ошибки пусть
		//		будет красным. Также добавьте кнопку «ОК», которая будет закрывать форму.
		#endregion
		#region 2
		//2. Теперь задание на укрепление знаний технологии WPF.
		//a.Добавить на главное окно тестового проекта WpfTestMailSender, в любое место формы два контрола TextBox, одно для названия письма, второе 
		//		для самого текста письма.И сделайте так, чтобы название письма и текст письма брались из этих контролов.

		//b.Скачать библиотеку стилей или тем (theme) с сайта http://wpfthemes.codeplex. Как описано в главе Изменение стиля приложения WPF, выберите 
		//		любой стиль по своему усмотрению и замените стиль, сделайте так же, как было описано на уроке.

		//c.Поиграйте с контролами тестового приложения WpfTestMailSender, поменяйте их свойства, поразмещайте в разных местах окна.Поменяйте основную 
		//		панель Grid на другие панели, которые мы рассматривали на уроке.
		#endregion
		#region 3
		//3. Заменить название основного окна и класса приложения MailSender, MainWindow на WpfMailSender, сделать по аналогии с тем, как мы меняли 
		//		название главного окна у тестового приложения WpfTestMailSender на уроке.
		#endregion

		public WpfMailSender()
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
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}

}

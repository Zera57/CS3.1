using MailSender.Data;
using MailSender.Infrastructure.Commands;
using MailSender.lib.Interfaces;
using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MailSender.ViewModels
{
	class MainWindowViewModel : ViewModel
	{
		public MainWindowViewModel(IMailService MailService)
		{
			_MailService = MailService;
			Servers = new ObservableCollection<Server>(TestData.Servers);
			Senders = new ObservableCollection<Sender>(TestData.Senders);
			Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
			Messages = new ObservableCollection<Message>(TestData.Messages);
		}

		private readonly IMailService _MailService;
		private ObservableCollection<Server> _Servers;
		private ObservableCollection<Sender> _Senders;
		private ObservableCollection<Recipient> _Recipients;
		private ObservableCollection<Message> _Messages;

		private string _Title = "Отпращик почты";
		
		public string Title
		{
			get => _Title;
			set
			{
				if (_Title == value) return;
				_Title = value;
				OnPropertyChanged("Title");
			}
		}

		public ObservableCollection<Server> Servers
		{
			get => _Servers;
			set => Set(ref _Servers, value);
		}

		public ObservableCollection<Sender> Senders
		{
			get => _Senders;
			set => Set(ref _Senders, value);
		}

		public ObservableCollection<Recipient> Recipients
		{
			get => _Recipients;
			set => Set(ref _Recipients, value);
		}

		public ObservableCollection<Message> Messages
		{
			get => _Messages;
			set => Set(ref _Messages, value);
		}


		private Server _SelectedServer;

		public Server SelectedServer
		{
			get => _SelectedServer;
			set => Set(ref _SelectedServer, value);
		}

		private Sender _SelectedSender;

		public Sender SelectedSender
		{
			get => _SelectedSender;
			set => Set(ref _SelectedSender, value);
		}

		private Recipient _SelectedRecipient;

		public Recipient SelectedRecipient
		{
			get => _SelectedRecipient;
			set => Set(ref _SelectedRecipient, value);
		}

		private Message _SelectedMessage;

		public Message SelectedMessage
		{
			get => _SelectedMessage;
			set => Set(ref _SelectedMessage, value);
		}

		#region Commands
		private ICommand _ShowDialogCommand;

		public ICommand ShowDialogCommand => _ShowDialogCommand
			??= new DelegateCommand(OnShowDialogCommandExecuted);

		private void OnShowDialogCommandExecuted(object p)
		{
			MessageBox.Show("hell world");
		}

		private ICommand _DeleteServerCommand;

		public ICommand DeleteServerCommand => _DeleteServerCommand
			??= new DelegateCommand(OnDeleteServerCommandExecuted, CanDeleteServerExecute);

		private bool CanDeleteServerExecute(object p) => p is Server || SelectedServer != null;

		private void OnDeleteServerCommandExecuted(object p)
		{
			var server = p as Server ?? SelectedServer;
			if (server is null) return;

			Servers.Remove(server);
			SelectedServer = Servers.FirstOrDefault();
		}

		private ICommand _SendMailCommand;

		public ICommand SendMailCommand => _SendMailCommand
			??= new DelegateCommand(OnSendMailCommandExecuted, CanSendMailExecute);

		private bool CanSendMailExecute(object p)
		{
			if (SelectedServer is null || SelectedSender is null || SelectedRecipient is null || SelectedMessage is null)
				return false;
			return true;
		}

		private void OnSendMailCommandExecuted(object p)
		{
			var mail_sender = _MailService.GetSender(SelectedServer.Address, SelectedServer.Port, SelectedServer.UseSSL, SelectedServer.Login, SelectedServer.Password);
			mail_sender.Send(SelectedSender.Address, SelectedRecipient.Address, SelectedMessage.Subject, SelectedMessage.Body);
		}
		#endregion
	}

}

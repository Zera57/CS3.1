using MailSender.Infrastructure.Commands;
using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MailSender.ViewModels
{
	class MainWindowViewModel : ViewModel
	{
		private string _Title = "Тестовое окно";

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

		private ICommand _ShowDialogCommand;

		public ICommand ShowDialogCommand => _ShowDialogCommand
			??= new DelegateCommand(OnShowDialogCommandExecuted);

		private void OnShowDialogCommandExecuted(object p)
		{
			MessageBox.Show("hell world");
		}

		private ObservableCollection<Server> _Servers;
		private ObservableCollection<Sender> _Senders;
		private ObservableCollection<Recipient> _Recipients;
		private ObservableCollection<Message> _Messages;

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
	}

}

using MailSender.Infrastructure.Commands;
using System;
using System.Collections.Generic;
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
	}
}

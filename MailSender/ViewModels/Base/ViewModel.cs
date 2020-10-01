using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MailSender.ViewModels
{
	class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string PropertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
		}
	}
}

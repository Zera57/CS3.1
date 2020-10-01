using MailSender.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Infrastructure.Commands
{
	class DelegateCommand : Command
	{
		private readonly Action<object> _Execute;

		private readonly Func<object, bool> _CanExecute;

		public DelegateCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
		{
			_Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
			_CanExecute = CanExecute;
		}

		protected override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;

		protected override void Execute(object p) => _Execute(p);

		
	}
}

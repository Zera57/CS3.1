using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Interfaces
{
	interface IMailService
	{
		IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password);
	}

	interface IMailSender
	{
		void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);
	}
}

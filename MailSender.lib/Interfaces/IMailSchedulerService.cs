using MailSender.lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Interfaces
{
	interface IMailSchedulerService
	{
		void Start();

		void Stop();

		void AddTask(DateTime Time, Sender sender, IEnumerable<Recipient>, Server Server, Message Message);
	}
}

using MailSender.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Data
{
	class MailSenderDbInitializer
	{
		private readonly MailSenderDB _DB;

		public MailSenderDbInitializer(MailSenderDB DB) => _DB = DB;

		public void Initialize()
		{
			_DB.Database.Migrate();

			InitializeRecipients();
			InitializeSenders();
			InitializeServers();
			InitializeMessages();
		}

		private void InitializeRecipients()
		{
			if (_DB.Recipients.Any()) return;

			_DB.Recipients.AddRange(TestData.Recipients);
			_DB.SaveChanges();
		}

		private void InitializeSenders()
		{
			if (_DB.Senders.Any()) return;

			_DB.Senders.AddRange(TestData.Senders);
			_DB.SaveChanges();
		}

		private void InitializeServers()
		{
			if (_DB.Servers.Any()) return;

			_DB.Servers.AddRange(TestData.Servers);
			_DB.SaveChanges();
		}

		private void InitializeMessages()
		{
			if (_DB.Messages.Any()) return;

			_DB.Messages.AddRange(TestData.Messages);
			_DB.SaveChanges();
		}
	}
}

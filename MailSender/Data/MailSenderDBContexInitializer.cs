using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Data
{
	class MailSenderDBContexInitializer : IDesignTimeDbContextFactory<MailSenderDB>
	{
		public MailSenderDB CreateDbContext(string[] args)
		{
			const string connection_string = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Zera57\source\repos\CS3.1\MailSender\DB\MailSenderDB.mdf; Integrated Security = True";

			var optionsBuilder = new DbContextOptionsBuilder<MailSenderDB>();
			optionsBuilder.UseSqlServer(connection_string);

			return new MailSenderDB(optionsBuilder.Options);
		}
	}
}

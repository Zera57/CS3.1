using MailSender.Data;
using MailSender.lib.Interfaces;
using MailSender.lib.Service;
using MailSender.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace MailSender
{
	public partial class App
	{
		private static IHost _Hosting;

		public static IHost Hosting => _Hosting
			??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
			.ConfigureAppConfiguration(cfg => cfg.AddJsonFile("appconfig.json"))
			.ConfigureServices(ConfigureServices)
			.Build();

		public static IServiceProvider Services => Hosting.Services;

		private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
		{
			services.AddSingleton<MainWindowViewModel>();
			services.AddSingleton<IEncryptorService, Rfc2898Encryptor>();
			services.AddTransient<IMailService, SmtpMailService>();
			services.AddDbContext<MailSenderDB>(opt => opt.UseSqlServer(host.Configuration.GetConnectionString("Default")));
			services.AddTransient<MailSenderDbInitializer>();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			Services.GetRequiredService<MailSenderDbInitializer>().Initialize();
			base.OnStartup(e);
		}
	}
}

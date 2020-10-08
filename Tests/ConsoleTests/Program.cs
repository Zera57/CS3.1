using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace ConsoleTests
{
	class Program
	{
		static void Main(string[] args)
		{
			var Timer_Thread = new Thread(Timer);

			Timer_Thread.Name = "timer";

			Timer_Thread.Start();

			Console.WriteLine("Main thread is done.");
			ThreadInfo();
		}

		public static void Timer()
		{
			ThreadInfo();
			while(true)
			{
				Console.Title = DateTime.Now.ToString("HH:mm:ss");
				Thread.Sleep(100);
			}
		}

		public static void ThreadInfo()
		{
			var thread = Thread.CurrentThread;
			Console.WriteLine($"id:\t\t{thread.ManagedThreadId}; \nname:\t\t{thread.Name}; \npriority:\t{thread.Priority}\n");
		}
	}
}

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
			#region
			//var Timer_Thread = new Thread(Timer);

			//Timer_Thread.Name = "timer";

			//Timer_Thread.Start();

			//Console.WriteLine("Main thread is done.");
			//ThreadInfo();
			#endregion
			Console.WriteLine("Type number");
			factorial(Convert.ToInt32(Console.ReadLine()));
		}

		static long result = 1;
		static bool done = false;

		static void factorial(int n)
		{
			var func1 = new Thread(() => f1(n));
			func1.Start();
			var func2 = new Thread(() => f2(n));
			func2.Start();
		}

		static void f1(int n)
		{
			for (int i = 1; i <= n/2; i++)
			{
				result *= i;
			}
			Print_Result(n);
		}

		static void f2(int n)
		{
			for (int i = n/2+1; i <= n; i++)
			{
				result *= i;
			}
			Print_Result(n);
		}

		static void Print_Result(int n)
		{
			if (done == false)
				done = true;
			else
				Console.WriteLine($"Facrotial for {n} is {result}");
		}

		public static void ThreadInfo()
		{
			var thread = Thread.CurrentThread;
			Console.WriteLine($"id:\t\t{thread.ManagedThreadId}; \nname:\t\t{thread.Name}; \npriority:\t{thread.Priority}\n");
		}
	}
}

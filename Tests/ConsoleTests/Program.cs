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

		static long f_result = 1;
		static bool f_done = false;

		static long s_result = 0;
		static bool s_done = false;


		static void factorial(int n)
		{
			var func1 = new Thread(() => f1(n));
			func1.Start();
			var func2 = new Thread(() => f2(n));
			func2.Start();
			var sum1 = new Thread(() => s1(n));
			sum1.Start();
			var sum2 = new Thread(() => s2(n));
			sum2.Start();
		}

		static void f1(int n)
		{
			for (int i = 1; i <= n/2; i++)
			{
				f_result *= i;
			}
			Print_F_Result(n);
		}

		static void f2(int n)
		{
			for (int i = n/2+1; i <= n; i++)
			{
				f_result *= i;
			}
			Print_F_Result(n);
		}

		static void s1(int n)
		{
			for (int i = 1; i <= n / 2; i++)
			{
				s_result += i;
			}
			Print_S_Result(n);
		}

		static void s2(int n)
		{
			for (int i = n / 2 + 1; i < n; i++)
			{
				s_result += i;
			}
			Print_S_Result(n);
		}

		static void Print_F_Result(int n)
		{
			if (f_done == false)
				f_done = true;
			else
				Console.WriteLine($"Facrotial for {n} is {f_result}");
		}

		static void Print_S_Result(int n)
		{
			if (s_done == false)
				s_done = true;
			else
				Console.WriteLine($"Sum of all numbers bellow {n} is {s_result}");
		}

		public static void ThreadInfo()
		{
			var thread = Thread.CurrentThread;
			Console.WriteLine($"id:\t\t{thread.ManagedThreadId}; \nname:\t\t{thread.Name}; \npriority:\t{thread.Priority}\n");
		}
	}
}

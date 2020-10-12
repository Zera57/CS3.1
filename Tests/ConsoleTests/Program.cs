using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTests
{
	class Program
	{

		static int[,] a = new int[3, 3]
		{
			{ 1, 2, 3 },
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};


		static int[,] b = new int[3,3]
		{
			{ 1, 2, 3 },
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};

		static void Main(string[] args)
		{
			
			var task = Matrix_Multiply_Async.StartAsync(a, b);

			task.Wait();

			Console.WriteLine("Задача выполнена");
		}
	}

	static class Matrix_Multiply_Async
	{
		static void Print_Matrix(int[,] result)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.Write(result[i, j] + "\t");
				}
				Console.WriteLine();
			}
		}

		static public async Task StartAsync(int[,] a, int[,] b)
		{
			var c = new int[3,3];


			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					var result = await GetResultAsync(a, b, i, j);

					c[i, j] = result;
				}
			}
			Print_Matrix(c);
		}

		public static Task<int> GetResultAsync(int[,] a, int[,] b, int i, int j)
		{
			return Task.Run(() =>
			{
				int result = 0;
				for (int z = 0; z < 3; z++)
				{
					result += a[i, z] * b[z, j];
				}
				return result;
			});
		}

	}
}

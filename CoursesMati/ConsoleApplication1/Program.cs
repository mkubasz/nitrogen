using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			int k=0;
			//k = Convert.ToInt32(Console.ReadLine());
			try
			{
				k = Convert.ToInt32(Console.ReadLine());
			}
			catch (SystemException exception)
			{

				Console.WriteLine(exception.StackTrace);
				//throw;
			}
			finally
			{
				Console.WriteLine(k.ToString());
			}
			//Console.WriteLine(k.ToString());
		}
	}
}

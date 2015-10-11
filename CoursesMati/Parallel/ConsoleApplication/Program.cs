using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Parallel;
using Parallel = System.Threading.Tasks.Parallel;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			ClassTasks myClass = new ClassTasks();
			System.Threading.Tasks.Parallel.For(1, 100, (i, stanPetli) =>
			{
				
				Console.WriteLine("Stan petli to{0}",i);
				stanPetli.Stop();
			}
			
			);
		}
	}
}

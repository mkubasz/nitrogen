using System;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{
	public class ClassTasks
	{
		object _object = new object();

		public void Run()
		{
			if (Monitor.TryEnter(_object))
			{
				
				try
				{
					Thread.Sleep(100);
					Console.WriteLine("Monitor"+ Environment.TickCount);
				}
				finally
				{
					Monitor.Exit(_object);
				}
			}
		}
	}
}
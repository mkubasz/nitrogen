using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConverterDll.Excel
{
    class ConverterException : Exception
    {
        public ConverterException(string message) : base(message)
        {
			Console.WriteLine("dsadas");	
        }
    }
}

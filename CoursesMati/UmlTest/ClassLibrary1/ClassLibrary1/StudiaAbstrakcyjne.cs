using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
	public abstract class StudiaAbstrakcyjne
	{
		protected virtual void GetMyType()
		{
			throw new System.NotImplementedException();
		}

		internal abstract void GetNameUniversitie();
	}
}
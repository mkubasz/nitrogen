using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
	public class Student : StudiaAbstrakcyjne
	{
		public IUczelnia IUczelnia
		{
			get
			{
				throw new System.NotImplementedException();
			}

			set
			{
			}
		}

		protected override void GetMyType()
		{
			throw new System.NotImplementedException();
		}

		public override void GetNameUniversitie()
		{
			throw new System.NotImplementedException();
		}
	}
}
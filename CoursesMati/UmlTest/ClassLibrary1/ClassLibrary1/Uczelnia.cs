using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
	public class Uczelnia : IUczelnia
	{
		public string NazwaUczelni { get; set; }
		public List<IUczelnia> RankingUczelniTop5(List<IUczelnia> uczelnie)
		{
			throw new NotImplementedException();
		}
	}
}
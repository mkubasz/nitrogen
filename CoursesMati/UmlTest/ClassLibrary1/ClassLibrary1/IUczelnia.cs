using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
	public interface IUczelnia
	{
		string NazwaUczelni { get; set; }

		List<IUczelnia> RankingUczelniTop5(List<IUczelnia> uczelnie);
	}
}
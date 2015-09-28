using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
	class Program
	{


		private object obj;
		static void Main(string[] args)
		{
			
            Stack<string> stack = new Stack<string>();
			stack.Push("Pierwszy");
			stack.Push("Drugi");
			stack.Push("Trzeci");

			//Console.WriteLine(stack.Pop());
			Queue<string> queue = new Queue<string>();
			queue.Enqueue("Pierwszy");
			queue.Enqueue("Drugi");
			queue.Enqueue("Trzeci");

			Array array ;
			array = System.Array.CreateInstance(typeof(string), 10);
			array.SetValue("jestem",1);
			array.GetValue(1);
			//Console.WriteLine(array.GetValue(1));
			ArrayList arrayList = new ArrayList();
			arrayList.Add("Jestem");
			//foreach (var item in arrayList)
			//{
			//	Console.WriteLine(item);
			//}
			List<string> list = new List<string>();
			list.Add("Jeden");
			list.Add("Dwa");
			list.Add("Dwa");
			list.Add("Trzy");

			list.Select(x=>x);
			// Miasta  Usunąć powtórzenia
			// Znaleźć konretne miasto
			// Znaleźć miasto na lite M
			// IndexOf znaleźć te miasta na M
			// Count policzyć miasta na litere L
			// Usunąć miasta Opole 
			// Dodać wymyślone miasto
			//
			Console.WriteLine(list.ToList()[0]);

			//Console.WriteLine(list.Select(x => x).Where(item => item == "Dwa"));
			foreach (var item in list.Distinct())
			{
				Console.WriteLine(item);
			}
			//Console.WriteLine(list[0]);
			LinkedList<string> linkedList = new LinkedList<string>();
			linkedList.AddFirst("Ja");
			linkedList.AddFirst("Ty");
			linkedList.AddLast("Jat");
			linkedList.AddLast("Tyt");
			foreach (var item in linkedList)
			{
			//	Console.WriteLine(item);
			}
			Dictionary<string, Dictionary<string,string>> dictionary = new Dictionary<string, Dictionary<string,string>>();
			dictionary.Add("Mateusz",new Dictionary<string, string>  {{"Opole","Ulica" }});
			//Console.WriteLine(dictionary["Mateusz"]["Opole"]);
			Hashtable hashtable = new Hashtable();
			hashtable.Add("#21423423","wartosc");
			IDictionaryEnumerator obj = hashtable.GetEnumerator();
            HashSet<string> hash = new HashSet<string>() {"Adam","Ewa","Szymon", "Szymon"};
			HashSet<string> hash2 = new HashSet<string>() { "Adam", "Marta", "Igor" };
			hash.IsProperSubsetOf(hash2);
			foreach (var item in hash)
			{
				//Console.WriteLine(item);

			}

			//Console.WriteLine(queue.Dequeue());
		}
	}
}

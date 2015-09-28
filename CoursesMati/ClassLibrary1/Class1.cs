using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace ClassLibrary1
{
    public class Class1
    {
		GenericClass<string,bool> myClass = new GenericClass<string,bool>("Jestem");
		GenericClass<int,int> myClassInt = new GenericClass<int,int>(1);
		GenericClass<NewType,object> myClassNewType = new GenericClass<NewType,object>(new NewType());
		GenericClass<Bitmap,Array> myClassBitMap = new GenericClass<Bitmap,Array>(new Bitmap("file.png"));
	}
}

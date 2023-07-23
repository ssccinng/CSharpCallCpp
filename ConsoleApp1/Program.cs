using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDll;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringArray2 stringArray2 = new StringArray2();
            var cc = CppDll.GetStringArray2(ref stringArray2);
            Console.WriteLine(stringArray2.vSupportValue[0]);
        }
    }
}

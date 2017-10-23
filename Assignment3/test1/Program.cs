using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enumgenlist;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<String> stringList = new GenericList<string>();

            stringList.Add("abc");
            stringList.Add("def");
            stringList.Add("ghi");
            stringList.Add("jkl");
            stringList.Add("mno");
            stringList.Add("pqr");

            // foreach
            foreach (string value in stringList)
            {
                Console.WriteLine(value);
            }

            // foreach without the syntax sugar
            IEnumerator<string> enumerator = stringList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string value = (string)enumerator.Current;
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = JDocument.Load("f_test.json");
            Console.ReadLine();
        }
    }
}

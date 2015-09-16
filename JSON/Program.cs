using System;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = JDocument.Load("f.json");
            Console.WriteLine(doc.Root["obj"]["inf"]["arr"][2]["o"]);
            Console.ReadLine();
        }
    }
}

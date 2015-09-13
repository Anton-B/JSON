using System;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = JDocument.Load("f.json");
            Console.WriteLine(doc.Root["obj"]["inf"]["arr"][1]["o"]);
            Console.ReadLine();
        }
    }
}

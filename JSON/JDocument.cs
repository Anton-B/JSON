using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JSON
{
    sealed class JDocument
    {
        public string Text { get; set; }
        public JAbstractObject Root { get; set; }      

        public static JDocument Load(string fileName)
        {
            JDocument JD = new JDocument();
            JD.Text = File.ReadAllText(fileName);
            Parser parser = new Parser(JD.Text);
            JD.Root = parser.Parse();
            return JD;
        }
    }
}

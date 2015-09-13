using System.IO;

namespace JSON
{
    sealed class JDocument
    {
        public JAbstractObject Root { get; set; }      

        public static JDocument Load(string fileName)
        {
            JDocument JD = new JDocument();
            Parser parser = new Parser(File.ReadAllText(fileName));
            JD.Root = parser.Parse();
            return JD;
        }
    }
}

using System.IO;

namespace JSON
{
    public sealed class JDocument
    {
        public JAbstractObject Root { get; set; }      

        public static JDocument Load(string jsonString)
        {
            JDocument JD = new JDocument();
            Parser parser = new Parser(jsonString);
            JD.Root = parser.Parse();
            return JD;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    sealed class Lexem
    {
        public JToken Token { get; set; }
        public string Text { get; set; }

        public Lexem(){}

        public Lexem(JToken token, string text)
        {
            Token = token;
            Text = text;
        }
    }
}

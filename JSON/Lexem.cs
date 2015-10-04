using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JSON
{
    public sealed class Lexem
    {
        public JToken Token { get; set; }
        public string Text { get; set; }
        public int Length { get; set; }
        public int Offset { get; set; }

        public Lexem(JToken token, string text, int offset)
        {
            Token = token;
            Text = text;
            Offset = offset;
            Length = text.Length;
            if (token == JToken.String)
                Length += 2;
        }
    }
}

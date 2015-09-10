using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class Lexer
    {
        private string text;
        private int position = -1;
        private int quoteFl = 0;

        public Lexer(){}

        public Lexer(string text)
        {
            this.text = text;
        }

        public Lexem Next()
        {
            position++;
            if (position >= text.Length)
                return null;
            while (char.IsWhiteSpace(text[position]))
                position++;
            int stringStart = -1, stringLength = 0;
            while (position < text.Length)
            {
                if (stringStart != -1)
                {
                    stringLength++;
                    if (text[position] == '"' || (quoteFl == 0 && (position + 1 < text.Length && text[position + 1] == ',' 
                        || text[position + 1] == '}' || char.IsWhiteSpace(text[position + 1]))))
                    {
                        if (text[position] == '"')
                        {
                            stringLength--;
                            quoteFl = 0;
                        }   
                        return new Lexem(JToken.String, text.Substring(stringStart, stringLength));
                    }
                    position++;
                    continue;
                }
                else
                {
                    switch (text[position])
                    {
                        case '{':
                            return new Lexem(JToken.OpenObjectBrace, text[position].ToString());
                        case '}':
                            return new Lexem(JToken.CloseObjectBrace, text[position].ToString());
                        case '[':
                            return new Lexem(JToken.OpenArrayBrace, text[position].ToString());
                        case ']':
                            return new Lexem(JToken.CloseArrayBrace, text[position].ToString());
                        case ',':
                            return new Lexem(JToken.Comma, text[position].ToString());
                        case ':':
                            return new Lexem(JToken.Colon, text[position].ToString());
                        case '"':
                            stringStart = ++position;
                            quoteFl = 1;
                            break;
                        default:
                            if (char.IsDigit(text[position]) || text[position] == '.')
                            {
                                stringStart = position;
                                break;
                            }
                            return new Lexem(JToken.String, text[position].ToString());
                    }
                }
            }
            return null;
        }
    }
}

namespace JSON
{
    class Lexer
    {
        private string text;
        private int position = -1;
        private bool quoteFl = false;

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
                    if (text[position] == '"' || (quoteFl == false && position + 1 < text.Length && (text[position + 1] == ',' 
                        || text[position + 1] == '}' || char.IsWhiteSpace(text[position + 1]))))
                    {
                        if (text[position] == '"')
                        {
                            stringLength--;
                            quoteFl = false;
                            return new Lexem(JToken.String, text.Substring(stringStart, stringLength));
                        }
                        string resString = text.Substring(stringStart, stringLength);
                        int n;                     
                        if (int.TryParse(resString, out n))
                            return new Lexem(JToken.Int, resString);
                        else if (TryParseDouble(resString))
                            return new Lexem(JToken.Double, resString);
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
                            quoteFl = true;
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

        private bool TryParseDouble(string resString)
        {
            foreach (char c in resString)
                if (!char.IsDigit(c) && c != '.')
                    return false;
            return true;
        }
    }
}

namespace JSON
{
    public class Lexer
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
            while (position < text.Length && char.IsWhiteSpace(text[position]))
                position++;
            int stringStart = -1, stringLength = 0;
            while (position < text.Length)
            {
                if (stringStart != -1)
                {
                    stringLength++;
                    if (text[position] == '"' || (quoteFl == false && position + 1 < text.Length && (text[position + 1] == ',' 
                        || text[position + 1] == '}' || text[position + 1] == ']' || char.IsWhiteSpace(text[position + 1]))))
                    {
                        if (text[position] == '"')
                        {
                            stringLength--;
                            quoteFl = false;
                            return new Lexem(JToken.String, text.Substring(stringStart, stringLength), position - stringLength - 1);
                        }
                        string resString = text.Substring(stringStart, stringLength);
                        int n;
                        if (int.TryParse(resString, out n))
                            return new Lexem(JToken.Int, resString, position + 1 - resString.Length);
                        else if (TryParseDouble(resString))
                            return new Lexem(JToken.Double, resString, position + 1 - resString.Length);
                        else if (resString == "true")
                            return new Lexem(JToken.True, resString, position + 1 - resString.Length);
                        else if (resString == "false")
                            return new Lexem(JToken.False, resString, position + 1 - resString.Length);
                        else if (resString == "null")
                            return new Lexem(JToken.Null, resString, position + 1 - resString.Length);
                    }
                    position++;
                    continue;
                }
                else
                {
                    switch (text[position])
                    {
                        case '{':
                            return new Lexem(JToken.OpenObjectBrace, text[position].ToString(), position);
                        case '}':
                            return new Lexem(JToken.CloseObjectBrace, text[position].ToString(), position);
                        case '[':
                            return new Lexem(JToken.OpenArrayBrace, text[position].ToString(), position);
                        case ']':
                            return new Lexem(JToken.CloseArrayBrace, text[position].ToString(), position);
                        case ',':
                            return new Lexem(JToken.Comma, text[position].ToString(), position );
                        case ':':
                            return new Lexem(JToken.Colon, text[position].ToString(), position );
                        case '"':
                            stringStart = ++position;
                            quoteFl = true;
                            break;
                        default:
                            stringStart = position;
                            break;
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

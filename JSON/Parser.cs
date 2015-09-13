namespace JSON
{
    class Parser
    {
        public string Text { get; set; }
        private string tempName;
        private JAbstractObject CurrentObject;

        public Parser() { }
        public Parser(string Text)
        {
            this.Text = Text;
        }
        
        public JAbstractObject Parse()
        {
            Lexer lexer = new Lexer(this.Text);
            Lexem currLexem = lexer.Next();
            while (currLexem != null)
            {
                if (currLexem.Token == JToken.OpenObjectBrace || currLexem.Token == JToken.OpenArrayBrace)
                {
                    JAbstractObject newObj;
                    if (currLexem.Token == JToken.OpenObjectBrace)
                        newObj = new JObject();
                    else
                        newObj = new JArray();
                    newObj.Name = tempName;
                    tempName = null;
                    newObj.Parent = CurrentObject;
                    CurrentObject = newObj;
                }
                else if (currLexem.Token == JToken.String || currLexem.Token == JToken.Int || currLexem.Token == JToken.Double)
                {
                    if ((tempName != null && CurrentObject is JObject) || (CurrentObject is JArray))
                    {
                        if (currLexem.Token == JToken.String)
                            AddValue<string>(currLexem.Text);
                        else if (currLexem.Token == JToken.Int)
                        {
                            int intNum;
                            int.TryParse(currLexem.Text, out intNum);
                            AddValue<int>(intNum);
                        }
                        else
                        {
                            double doubleNum;
                            ToDouble(currLexem.Text, out doubleNum);
                            AddValue<double>(doubleNum);
                        }
                    }
                    else
                        tempName = currLexem.Text;
                }
                else if (CurrentObject.Parent != null && (currLexem.Token == JToken.CloseArrayBrace || currLexem.Token == JToken.CloseObjectBrace))
                {
                    if (CurrentObject.Parent is JObject)
                        ((JObject)CurrentObject.Parent).objectDict.Add(CurrentObject.Name, CurrentObject);
                    else
                        ((JArray)CurrentObject.Parent).arrayList.Add(CurrentObject);
                    CurrentObject = CurrentObject.Parent;
                }
                currLexem = lexer.Next();
            }
            return CurrentObject;
        }

        private void ToDouble(string s, out double d)
        {
            int dot = s.IndexOf('.');
            int num;
            int.TryParse(s.Substring(0, dot), out num);
            d = 0;
            d += num;
            string fractionString = s.Substring(dot + 1);
            fractionString = "0," + fractionString;
            double fraction;
            double.TryParse(fractionString, out fraction);
            d += fraction;        
        }

        private void AddValue<T>(T lexem)
        {
            JAbstractObject newObj = new JValue<T>();
            ((JValue<T>)newObj).Value = lexem;
            newObj.Parent = CurrentObject;
            if (tempName != null && CurrentObject is JObject)
            {
                newObj.Name = tempName;
                ((JObject)CurrentObject).objectDict.Add(tempName, (JValue<T>)newObj);
                tempName = null;
            }
            else if (CurrentObject is JArray)
            {
                ((JArray)CurrentObject).arrayList.Add((JValue<T>)newObj);
                tempName = null;
            }
        }
    }
}

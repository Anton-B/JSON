using System;
using System.Collections.Generic;

namespace JSON
{
    class Parser
    {
        public string Text { get; set; }
        private string tempName;
        private JAbstractObject CurrentObject;

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
                    if (CurrentObject != null)
                        ((JValuesContainer)CurrentObject).AddValue(newObj);
                    newObj.Parent = CurrentObject;
                    CurrentObject = newObj;
                }
                else if (currLexem.Token == JToken.String || currLexem.Token == JToken.Int || currLexem.Token == JToken.Double 
                    || currLexem.Token == JToken.True || currLexem.Token == JToken.False || currLexem.Token == JToken.Null)
                {
                    if ((tempName != null && CurrentObject is JObject) || (CurrentObject is JArray))
                    {
                        if (currLexem.Token == JToken.String)
                            ((JValuesContainer)CurrentObject).AddValue<string>(currLexem.Text, tempName);
                        else if (currLexem.Token == JToken.Int)
                        {
                            int intNum;
                            int.TryParse(currLexem.Text, out intNum);
                            ((JValuesContainer)CurrentObject).AddValue<int>(intNum, tempName);
                        }
                        else if (currLexem.Token == JToken.Double)
                        {
                            double doubleNum;
                            double.TryParse(currLexem.Text.Replace('.', ','), out doubleNum);
                            ((JValuesContainer)CurrentObject).AddValue<double>(doubleNum, tempName);
                        }
                        else if (currLexem.Token == JToken.True)
                            ((JValuesContainer)CurrentObject).AddValue<bool>(true, tempName);
                        else if (currLexem.Token == JToken.False)
                            ((JValuesContainer)CurrentObject).AddValue<bool>(false, tempName);
                        else
                            ((JValuesContainer)CurrentObject).AddValue<object>(null, tempName);
                        tempName = null;
                    }
                    else
                        tempName = currLexem.Text;
                }
                else if (CurrentObject.Parent != null && (currLexem.Token == JToken.CloseArrayBrace || currLexem.Token == JToken.CloseObjectBrace))
                    CurrentObject = CurrentObject.Parent;
                currLexem = lexer.Next();
            }
            return CurrentObject;
        }
    }
}

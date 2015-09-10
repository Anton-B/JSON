using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class Parser
    {
        public string Text { get; set; }
        private JValue CurrentObject = null;

        public Parser() { }
        public Parser(string Text)
        {
            this.Text = Text;
        }
        
        public JValue Parse()
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
                    if (CurrentObject == null || CurrentObject.Type is JArray)
                    {
                        JValue newVal = new JValue();
                        newVal.Parent = CurrentObject;
                        CurrentObject = newVal;
                    }
                    CurrentObject.Type = newObj;
                }
                else if (currLexem.Token == JToken.String)
                {
                    JValue newObj = new JValue();
                    CurrentObject.Add(newObj);
                    if (CurrentObject.Type is JObject)
                    {
                        CurrentObject = newObj;
                        CurrentObject.Name = currLexem.Text;
                        CurrentObject.Type = new JValue();
                    }
                    else if (CurrentObject.Type is JValue)
                    {
                        CurrentObject.Type = new JValue();
                        CurrentObject.values.Last().Value = currLexem.Text;
                        CurrentObject = CurrentObject.Parent;
                    }
                    else if (CurrentObject.Type is JArray)
                        CurrentObject.values.Last().Value = currLexem.Text;
                }
                else if (CurrentObject.Parent != null && (currLexem.Token == JToken.CloseArrayBrace || currLexem.Token == JToken.CloseObjectBrace))
                {
                    if (CurrentObject.Parent.values.Last() != CurrentObject)
                        CurrentObject.Parent.Add(CurrentObject);
                    CurrentObject = CurrentObject.Parent;
                }
                currLexem = lexer.Next();
            }
            return CurrentObject;
        }
    }
}

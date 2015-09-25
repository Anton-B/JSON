using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JSON;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Formatter
{
    public class Formatter
    {
        public void Paste(TextBox tb)
        {
            tb.Focus();
            tb.Paste();
        }

        public void Copy(TextBox tb)
        {
            tb.Focus();
            tb.Copy();
        }

        public void Format(TextBox tb)
        {
            StringBuilder newText = new StringBuilder();
            int numOfSpaces = 0;
            Lexer lexer = new Lexer(tb.Text);
            Lexem lexem = lexer.Next();
            while (lexem != null)
            {
                if (lexem.Token == JToken.OpenArrayBrace || lexem.Token == JToken.OpenObjectBrace)
                {
                    numOfSpaces += 2;
                    lexem.Text = lexem.Text + "\n";
                    for (int i = 0; i < numOfSpaces; i++)
                        lexem.Text += " ";
                }
                else if (lexem.Token == JToken.Colon)
                    lexem.Text += " ";
                else if (lexem.Token == JToken.Comma)
                {
                    lexem.Text = lexem.Text + "\n";
                    for (int i = 0; i < numOfSpaces; i++)
                        lexem.Text += " ";
                }
                else if (lexem.Token == JToken.CloseArrayBrace || lexem.Token == JToken.CloseObjectBrace)
                {
                    numOfSpaces -= 2;
                    for (int i = 0; i < numOfSpaces; i++)
                        lexem.Text = " " + lexem.Text;
                    lexem.Text = "\n" + lexem.Text;
                }
                else if (lexem.Token == JToken.String)
                {
                    lexem.Text = "\"" + lexem.Text;
                    lexem.Text += "\"";
                }
                newText.Append(lexem.Text);
                lexem = lexer.Next();
            }
            if (newText != null)
                tb.Text = newText.ToString();
        }

        public void RemoveEmptyEntries(TextBox tb)
        {
            tb.Focus();
            string input = tb.Text;
            string pattern = "\\s";
            string replacement = "";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(input, replacement);
            tb.Text = result;
        }

        public void Clear(TextBox tb)
        {
            tb.Focus();
            tb.Text = "";
        }
    }
}

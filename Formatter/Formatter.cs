using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JSON;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Drawing;
using System.Windows.Media;

namespace JSON_Formatter
{
    public static class Formatter
    {
        public static string Format(string input)
        {
            int numOfSpaces = 0;
            StringBuilder newStr = new StringBuilder();
            Lexer lexer = new Lexer(input);
            Lexem lexem = lexer.Next();
            while (lexem != null)
            {
                StringBuilder subStr = new StringBuilder();
                if (lexem.Token == JToken.OpenArrayBrace || lexem.Token == JToken.OpenObjectBrace)
                {
                    numOfSpaces += 2;
                    subStr.Append(lexem.Text + "\n");
                    for (int i = 0; i < numOfSpaces; i++)
                        subStr.Append(" ");
                }
                else if (lexem.Token == JToken.Colon)
                    subStr.Append(lexem.Text + " ");                    
                else if (lexem.Token == JToken.Comma)
                {
                    subStr.Append(lexem.Text + "\n");
                    for (int i = 0; i < numOfSpaces; i++)
                        subStr.Append(" ");
                }
                else if (lexem.Token == JToken.CloseArrayBrace || lexem.Token == JToken.CloseObjectBrace)
                {
                    numOfSpaces -= 2;
                    subStr.Append("\n");
                    for (int i = 0; i < numOfSpaces; i++)
                        subStr.Append(" ");
                    subStr.Append(lexem.Text);
                }
                else if (lexem.Token == JToken.String)  
                    subStr.Append("\"" + lexem.Text + "\"");  
                else
                    subStr.Append(lexem.Text);
                newStr.Append(subStr);
                lexem = lexer.Next();
            }
            return newStr.ToString();
        }

        public static string RemoveEmptyEntries(string input)
        {
            Lexer lexer = new Lexer(input);
            Lexem lexem = lexer.Next();
            StringBuilder newText = new StringBuilder();
            while (lexem != null)
            {
                if (lexem.Token == JToken.String)
                    newText.Append("\"" + lexem.Text + "\"");
                else
                    newText.Append(lexem.Text);
                lexem = lexer.Next();
            }
            return newText.ToString();
        }
    }
}

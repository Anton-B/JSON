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

namespace Formatter
{
    public static class Formatter
    {
        public static FlowDocument Format(string input)
        {
            int numOfSpaces = 0;
            Lexer lexer = new Lexer(input);
            Lexem lexem = lexer.Next();
            FlowDocument document = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            Run tempStringRun = null;
            while (lexem != null)
            {
                StringBuilder subStr = new StringBuilder();
                Run run = new Run();
                if (lexem.Token == JToken.OpenArrayBrace || lexem.Token == JToken.OpenObjectBrace)
                {
                    numOfSpaces += 2;
                    subStr.Append(lexem.Text + "\n");
                    for (int i = 0; i < numOfSpaces; i++)
                        subStr.Append(" ");
                }
                else if (lexem.Token == JToken.Colon)
                {
                    AddString(ref paragraph, ref tempStringRun, lexem.Token);
                    subStr.Append(lexem.Text + " ");                    
                }
                else if (lexem.Token == JToken.Comma)
                {
                    AddString(ref paragraph, ref tempStringRun, lexem.Token);
                    subStr.Append(lexem.Text + "\n");
                    for (int i = 0; i < numOfSpaces; i++)
                        subStr.Append(" ");
                }
                else if (lexem.Token == JToken.CloseArrayBrace || lexem.Token == JToken.CloseObjectBrace)
                {
                    AddString(ref paragraph, ref tempStringRun, lexem.Token);
                    numOfSpaces -= 2;
                    subStr.Append("\n");
                    for (int i = 0; i < numOfSpaces; i++)
                        subStr.Append(" ");
                    subStr.Append(lexem.Text);
                }
                else if (lexem.Token == JToken.String)
                {   
                    subStr.Append("\"" + lexem.Text + "\"");
                    tempStringRun = new Run(subStr.ToString());
                    lexem = lexer.Next();
                    continue;
                }    
                else if (lexem.Token == JToken.True || lexem.Token == JToken.False || lexem.Token == JToken.Null)
                {
                    subStr.Append(lexem.Text);
                    run.Foreground = Colorizer.GetColor(lexem.Token);
                }
                else
                    subStr.Append(lexem.Text);
                run.Text = subStr.ToString();
                paragraph.Inlines.Add(run);
                lexem = lexer.Next();
            }
            document.Blocks.Add(paragraph);
            return document;
        }

        private static void AddString(ref Paragraph par, ref Run tempRun, JToken token)
        {
            if (tempRun == null)
                return;
            tempRun.Foreground = Colorizer.GetColor(token);
            par.Inlines.Add(tempRun);
            tempRun = null;
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

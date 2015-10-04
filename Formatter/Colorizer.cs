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
    static class Colorizer
    {
        public static FlowDocument Colorize(string input)
        {
            Lexer lexer = new Lexer(input);
            Lexem lastLexem = new Lexem(JToken.Null, "", 0);
            Lexem lexem = lexer.Next();
            FlowDocument document = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            Run tempStringRun = null;
            while (lexem != null)
            {
                StringBuilder subStr = new StringBuilder();
                Run run = new Run();
                subStr.Append(input.Substring(lastLexem.Offset + lastLexem.Length,
                       lexem.Offset - lastLexem.Offset - lastLexem.Length));
                if (lexem.Token == JToken.String)
                {
                    subStr.Append("\"" + lexem.Text + "\"");
                    tempStringRun = new Run(subStr.ToString());
                    lastLexem = lexem;
                    lexem = lexer.Next();
                    continue;
                }
                else
                {   
                    AddString(paragraph, ref tempStringRun, lexem.Token);
                    subStr.Append(lexem.Text);
                    if (lexem.Token == JToken.True || lexem.Token == JToken.False || lexem.Token == JToken.Null)
                        run.Foreground = GetColor(lexem.Token);
                }
                run.Text = subStr.ToString();
                paragraph.Inlines.Add(run);
                lastLexem = lexem;
                lexem = lexer.Next();
            }
            paragraph.Inlines.Add(new Run(input.Substring(lastLexem.Offset + lastLexem.Length)));
            document.Blocks.Add(paragraph);
            return document;
        }

        private static void AddString(Paragraph par, ref Run tempRun, JToken token)
        {
            if (tempRun == null)
                return;
            tempRun.Foreground = GetColor(token);
            par.Inlines.Add(tempRun);
            tempRun = null;
        }

        public static SolidColorBrush GetColor(JToken token)
        {
            if (token == JToken.Colon)
                return new SolidColorBrush(Colors.SteelBlue);
            else if (token == JToken.Comma || token == JToken.CloseArrayBrace || token == JToken.CloseObjectBrace)
                return new SolidColorBrush(Colors.DarkRed);
            else if (token == JToken.True || token == JToken.False || token == JToken.Null)
                return new SolidColorBrush(Colors.Blue);
            return new SolidColorBrush(Colors.Black);
        }
    }
}

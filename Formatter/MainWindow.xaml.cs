using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JSON;

namespace Formatter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.Text = "";
        }

        private void bt_remove_space_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            string t = textBox.Text;
            t = t.Replace("\n", "");
            t = t.Replace("\t", "");
            t = t.Replace("\r", "");
            t = t.Replace("\v", "");
            t = t.Replace(" ", "");
            textBox.Text = t;
        }

        private void bt_format_Click(object sender, RoutedEventArgs e)
        {
            bt_remove_space_Click(sender, e);
            string newText = "";
            int numOfSpaces = 0;
            Lexer lexer = new Lexer(textBox.Text);
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
                newText += lexem.Text;
                lexem = lexer.Next();
            }
            if (newText != "")
                textBox.Text = newText;
        }

        private void bt_paste_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.Paste();
        }

        private void bt_copy_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.Copy();
        }
    }
}
